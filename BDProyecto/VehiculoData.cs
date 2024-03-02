using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class VehiculoData
    {
        public static int insertar_vehiculo_Quito(Vehiculo vehiculo, string conexion)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            int retorno = 0;
            using (sqlConnection)
            {
                string query = "insert into vehiculo (placa, nombre_cliente, apellido_cliente, cod_taller, num_matricula," +
                    $" fecha_compra) values ({vehiculo.placa},{vehiculo.nombre_cliente}," +
                    $"{vehiculo.apellido_cliente},{vehiculo.cod_taller},{vehiculo.num_matricula}," +
                    $"{vehiculo.fecha_compra})";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                retorno = cmd.ExecuteNonQuery();

            }
            sqlConnection.Close();
            return retorno;
        }
        public static List<Vehiculo> mostrar_vehiculos(string conexion)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            List<Vehiculo> lista = new List<Vehiculo>();
            using (sqlConnection)
            {
                
                string query = "select placa, nombre_cliente, apellido_cliente, cod_taller, num_matricula, fecha_compra" +
                    " from vehiculo";
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
                    Vehiculo vehiculo = new Vehiculo();
                    vehiculo.placa = reader.GetString(0);
                    vehiculo.nombre_cliente = reader.GetString(1);
                    vehiculo.apellido_cliente = reader.GetString(2);
                    vehiculo.cod_taller = reader.GetInt32(3);
                    vehiculo.num_matricula = reader.GetString(4);
                    vehiculo.fecha_compra = reader.GetDateTime(5);
                    lista.Add(vehiculo);
                }
                sqlConnection.Close();
                return lista;
            }

        }
        public static int actualizar_vehiculos_Quito(Vehiculo vehiculo_Quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"update vehiculo set placa={vehiculo_Quito.placa}," +
                    $" nombre_cliente={vehiculo_Quito.nombre_cliente}, apellido_cliente={vehiculo_Quito.apellido_cliente}," +
                    $" cod_taller={vehiculo_Quito.cod_taller}, num_matricula={vehiculo_Quito.num_matricula}," +
                    $" fecha_compra={vehiculo_Quito.fecha_compra} from vehiculo where" +
                    $"nombre_cliente={vehiculo_Quito.nombre_cliente} and apellido_cliente={vehiculo_Quito.apellido_cliente}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static int eliminar_vehiculo_Quito(Vehiculo vehiculo_Quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"delete from vehiculo where placa ={vehiculo_Quito.placa} and " +
                    $"nombre_cliente={vehiculo_Quito.nombre_cliente} and apellido_cliente={vehiculo_Quito.apellido_cliente}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
    }
}
