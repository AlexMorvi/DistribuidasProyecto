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
    public class ReparacionData
    {
        public static int insertar_reparacion(Reparacion reparacion, string conexion)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion); 
            sqlConnection.Open();
            int retorno = 0;
            using (sqlConnection)
            {
                string query = "insert into reparacion (placa, cod_reparacion, cod_taller, tipo_reparacion, precio, fecha_reparacion, observaciones)" +
                    $"values ({reparacion.placa},{reparacion.cod_reparacion}, {reparacion.cod_taller}, {reparacion.tipo_reparacion},{reparacion.precio},{reparacion.fecha_reparacion},{reparacion.observaciones})";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                retorno = cmd.ExecuteNonQuery();

            }
            sqlConnection.Close();
            return retorno;
        }
        public static List<Reparacion> mostrar_reparacion(string conexion)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            List<Reparacion> lista = new List<Reparacion>();
            using (sqlConnection)
            {
                string query = "select placa, cod_reparacion, cod_taller, tipo_reparacion, precio, fecha_reparacion, observaciones from reparacion";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reparacion reparacion = new Reparacion();
                    reparacion.placa = reader.GetString(0);
                    reparacion.cod_reparacion = reader.GetInt32(1);
                    reparacion.cod_taller = reader.GetInt32(2);
                    reparacion.tipo_reparacion = reader.GetString(3);
                    reparacion.precio = reader.GetDecimal(4);
                    reparacion.fecha_reparacion = reader.GetDateTime(5);
                    reparacion.observaciones = reader.GetString(6);
                    lista.Add(reparacion);
                }
                sqlConnection.Close();
                return lista;
            }

        }
        public static int actualizar_datos_reparacion_Quito(Reparacion reparacion, string conexion)
        {
            SqlConnection sqlConnection = new SqlConnection (conexion);
            sqlConnection.Open();
            int retorno = 0;
            using (sqlConnection)
            {
                string query = $"update reparacion_Quito set tipo_reparacion={reparacion.tipo_reparacion},precio={reparacion.precio},fecha_reparacion={reparacion.fecha_reparacion},observaciones={reparacion.observaciones} from reparacion where" +
                    $"placa = {reparacion.placa} and cod_reparacion={reparacion.cod_reparacion} and cod_taller = {reparacion.cod_taller}";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                retorno = cmd.ExecuteNonQuery();
            }
            sqlConnection.Close();
            return retorno;
        }
        public static int eliminar_reparacion_Quito(Reparacion reparacion, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"delete from reparacion_Quito where nplaca = {reparacion.placa} and cod_reparacion={reparacion.cod_reparacion}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
    }
}
