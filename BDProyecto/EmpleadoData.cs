﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Policy;
using BDProyecto;
using System.Collections;
namespace BDProyecto
{
    public class EmpleadoData
    {
        public static int insertar_empleado(Empleado empleado, string conexion)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            int retorno = 0;
            using (sqlConnection)
            {
                string query = "insert into empleado (cod_empleado, cod_taller, cedula_empleado, " +
                    $" nombre_empleado, apellido_empleado, salario, fecha_inicio) values" +
                    $" ({empleado.cod_empleado},{empleado.cod_taller},'{empleado.cedula_empleado}'," +
                    $" '{empleado.nombre_empleado}','{empleado.apellido_empleado}',{empleado.salario}," +
                    $" '{empleado.fecha_inicio})'";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                retorno = cmd.ExecuteNonQuery();
            }
            sqlConnection.Close();
            return retorno;
        }

        public static List<Empleado> mostrar_empleados(String conexion)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            List<Empleado> lista = new List<Empleado>();
            using (sqlConnection)
            {
                string query = "select cod_empleado, cod_taller, cedula_empleado, nombre_empleado, apellido_empleado, salario, fecha_inicio from empleado ";
                if (conexion.Contains("QUITO"))
                {
                    query += " where cod_taller = 1";
                }
                if (conexion.Contains("GUAYAQUIL"))
                {
                    query += " where cod_taller = 2";
                }

                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.cod_empleado = reader.GetInt32(0);
                    empleado.cod_taller = reader.GetInt32(1);
                    empleado.cedula_empleado = reader.GetString(2);
                    empleado.nombre_empleado = reader.GetString(3);
                    empleado.apellido_empleado = reader.GetString(4);
                    empleado.salario = reader.GetDecimal(5);
                    empleado.fecha_inicio = reader.GetDateTime(6);
                    lista.Add(empleado);
                }
                sqlConnection.Close();
                return lista;
            }

        }
        public static int actualizar_empleado(Empleado empleado, string conexion)
        {

            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            int retorno = 0;
            using (sqlConnection)
            {
                string query = $"update empleado set cedula_empleado={empleado.cedula_empleado}," +
                    $" nombre_empleado={empleado.nombre_empleado}, apellido_empleado={empleado.apellido_empleado}," +
                    $" salario={empleado.salario}, fecha_inicio={empleado.fecha_inicio}" +
                    $" where nombre_empelado={empleado.nombre_empleado} and apellido_empleado={empleado.apellido_empleado}";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                retorno = cmd.ExecuteNonQuery();
            }
            sqlConnection.Close();
            return retorno;

        }
        public static int eliminar_empleado(Empleado empleado, string conexion)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            int retorno = 0;
            using (sqlConnection)
            {
                string query = $"delete from empleado where cod_empleado={empleado.cod_empleado} and " +
                    $"nombre_empleado={empleado.nombre_empleado} and" +
                    $" apellido_empleado={empleado.apellido_empleado}";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                retorno = cmd.ExecuteNonQuery();
            }
            sqlConnection.Close();
            return retorno;
        }
    }
}
