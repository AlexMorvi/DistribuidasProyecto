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
    public class ClienteData
    {
        public static int insertar_cliente(Cliente cliente, string conexion)
        {
            SqlConnection sqlConnection = new SqlConnection (conexion);
            sqlConnection.Open ();
            int retorno = 0;
            using (sqlConnection)
            {
                string query = "insert into cliente (nombre_cliente, apellido_cliente, cod_taller, cedula_cliente, ciudad_residencia, telefono) " +
                    $"values ('{cliente.nombre_cliente}','{cliente.apellido_cliente}',{cliente.cod_taller},'{cliente.cedula_cliente}','{cliente.ciudad_residencia}','{cliente.telefono}')";
                
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                retorno = cmd.ExecuteNonQuery();

            }
            sqlConnection.Close();
            return retorno;
        }
        public static List<Cliente> mostrar_clientes(string conexion)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open ();
            List<Cliente> lista = new List<Cliente>();
            using (sqlConnection)
                
            {
                string query = "select nombre_cliente, apellido_cliente, cod_taller, cedula_cliente, ciudad_residencia, telefono from cliente";
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
                    Cliente cliente = new Cliente();
                    cliente.nombre_cliente = reader.GetString(0);
                    cliente.apellido_cliente = reader.GetString(1);
                    cliente.cod_taller = reader.GetInt32(2);
                    cliente.cedula_cliente = reader.GetString(3);
                    cliente.ciudad_residencia = reader.GetString(4);
                    cliente.telefono = reader.GetString(5);
                    lista.Add(cliente);
                }
                sqlConnection.Close();
                //conexion.cerrar_Conexion();
                return lista;
            }
            

        }
        public static int actualizar_datos_cliente(Cliente cliente, string conexion)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            int retorno = 0;
            using (sqlConnection)
            {
                string query = $"update cliente set nombre_cliente={cliente.nombre_cliente}, apellido_cliente={cliente.apellido_cliente}, cod_taller={cliente.cod_taller}, cedula_cliente={cliente.cedula_cliente}, ciudad_residencia={cliente.ciudad_residencia}, telefono={cliente.telefono} from cliente where" +
                    $"nombre_cliente={cliente.nombre_cliente} and apellido_cliente={cliente.apellido_cliente}";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                retorno = cmd.ExecuteNonQuery();
            }
            sqlConnection.Close();
            return retorno;
        }
        public static int eliminar_cliente(Cliente cliente, string conexion)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            int retorno = 0;
            using (sqlConnection)
            {
                
                string query = $"delete from cliente where nombre_cliente={cliente.nombre_cliente} and apellido_cliente={cliente.apellido_cliente}";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                retorno = cmd.ExecuteNonQuery();
            }
            sqlConnection.Close();
            return retorno;
        }
    }
}
