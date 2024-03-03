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
        public static int insertar_vehiculo(Vehiculo vehiculo, string conexion)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            int retorno = 0;
            using (sqlConnection)
            {
                string query = "insert into vehiculo (placa, nombre_cliente, apellido_cliente, cod_taller, num_matricula, fecha_compra)"+
                    $" values ('{vehiculo.placa}','{vehiculo.nombre_cliente}','{vehiculo.apellido_cliente}',{vehiculo.cod_taller},'{vehiculo.num_matricula}','{vehiculo.fecha_compra}')";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                retorno = cmd.ExecuteNonQuery();
                string query_extra = "insert into placa_Vehiculo (placa)" +
                    $" values ('{vehiculo.placa}')";
                SqlCommand cmd2 = new SqlCommand(query_extra, sqlConnection);
                retorno = cmd2.ExecuteNonQuery();

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
        public static int actualizar_vehiculos(Vehiculo vehiculo, string conexion)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            int retorno = 0;
            using (sqlConnection)
            {
                string query = $"update vehiculo set num_matricula='{vehiculo.num_matricula}'," +
                    $" fecha_compra='{vehiculo.fecha_compra}' from vehiculo where" +
                    $" placa = '{vehiculo.placa}' and cod_taller = {vehiculo.cod_taller}";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                retorno = cmd.ExecuteNonQuery();
            }
            sqlConnection.Close();
            return retorno;
        }
        public static int eliminar_vehiculo(Vehiculo vehiculo, string conexion)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            int retorno = 0;
            using (sqlConnection)
            {
                string query = $"delete from vehiculo where placa ='{vehiculo.placa}' and " +
                    $"cod_taller = {vehiculo.cod_taller}";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                retorno = cmd.ExecuteNonQuery();
                string query_extra = $"delete from placa_Vehiculo where placa = '{vehiculo.placa}'";
                SqlCommand cmd2 = new SqlCommand (query_extra, sqlConnection);
                retorno = cmd2.ExecuteNonQuery();
            }
            sqlConnection.Close();
            return retorno;
        }
       
    }
}
