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
        public static int insertar_cliente(Reparacion reparacion_Quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "insert into reparacion_Quito (placa, cod_reparacion, tipo_reparacion, precio, fecha_reparacion, observaciones)" +
                    $"values ({reparacion_Quito.placa},{reparacion_Quito.cod_reparacion}, {reparacion_Quito.cod_taller}, {reparacion_Quito.tipo_reparacion},{reparacion_Quito.precio},{reparacion_Quito.fecha_reparacion},{reparacion_Quito.observaciones})";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();

            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static List<Reparacion> mostrar_reparacion_Quito(Conexion conexion)
        {
            List<Reparacion> lista = new List<Reparacion>();
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "select placa, cod_reparacion, cod_taller, tipo_reparacion, precio, fecha_reparacion, observaciones";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reparacion reparacion = new Reparacion();
                    reparacion.placa = reader.GetString(0);
                    reparacion.cod_reparacion = reader.GetInt32(1);
                    reparacion.cod_taller = reader.GetInt32(2);
                    reparacion.tipo_reparacion = reader.GetString(3);
                    reparacion.precio = reader.GetInt32(4);
                    reparacion.fecha_reparacion = reader.GetDateTime(5);
                    reparacion.observaciones = reader.GetString(6);
                    lista.Add(reparacion);
                }
                conexion.cerrar_Conexion();
                return lista;
            }

        }
        public static int actualizar_datos_reparacion_Quito(Reparacion reparacion_Quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"update reparacion_Quito set placa = {reparacion_Quito.placa},cod_reparacion={reparacion_Quito.cod_reparacion},cod_taller={reparacion_Quito.cod_taller},tipo_reparacion={reparacion_Quito.tipo_reparacion},precio={reparacion_Quito.precio},fecha_reparacion={reparacion_Quito.fecha_reparacion},observaciones={reparacion_Quito.observaciones} from reparacion_Quito where" +
                    $"placa = {reparacion_Quito.placa} and cod_reparacion={reparacion_Quito.cod_reparacion}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static int eliminar_reparacion_Quito(Reparacion reparacion_Quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"delete from reparacion_Quito where nplaca = {reparacion_Quito.placa} and cod_reparacion={reparacion_Quito.cod_reparacion}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
    }
}
