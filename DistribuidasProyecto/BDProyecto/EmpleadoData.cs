using System;
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
        public static int insertar_empleado_quito(Empleado empleado, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "insert into empleado_Quito (cod_empleado, cod_taller, cedula_empleado, nombre_empleado, apellido_empleado, salario, fecha_inicio) " +
                    $"values ({empleado.cod_empleado},{empleado.cod_taller},{empleado.cedula_empleado},{empleado.nombre_empleado},{empleado.apellido_empleado},{empleado.salario},{empleado.fecha_inicio})";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();

            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static List<Empleado> mostrar_empleado_quito(Conexion conexion)
        {
            List<Empleado> lista = new List<Empleado>();
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "select cod_empleado, cod_taller, cedula_empleado, nombre_empleado, apellido_empleado, salario, fecha_inicio";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.cod_empleado = reader.GetInt32(0);
                    empleado.cod_taller = reader.GetInt32(1);
                    empleado.cedula_empleado = reader.GetString(2);
                    empleado.nombre_empleado = reader.GetString(3);
                    empleado.apellido_empleado = reader.GetString(4);
                    empleado.salario = reader.GetInt32(5);
                    empleado.fecha_inicio = reader.GetDateTime(6);
                    lista.Add(empleado);
                }
                conexion.cerrar_Conexion();
                return lista;
            }

        }
        public static int actualizar_empleado_quito(Empleado empleado, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"update empleado_Quito set cod_empleado={empleado.cod_empleado}, cod_taller = {empleado.cod_taller}, cedula_empleado = {empleado.cedula_empleado},nombre_empleado = {empleado.nombre_empleado},apellido_empleado={empleado.apellido_empleado},salario={empleado.salario},fecha_inicio={empleado.fecha_inicio} from empleado_Quito where" +
                    $"cod_empleado={empleado.cod_empleado}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static int eliminar_empleado_quito(Empleado empleado, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"delete from empleado_Quito where cod_empleado={empleado.cod_empleado}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
    }
}
