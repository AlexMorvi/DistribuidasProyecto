using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class TelefonoData
    {
        public static int insertar_telefono_Quito(Telefono telefono_Quito, string conexion) 
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            int retorno = 0;
            using (sqlConnection) 
            {
                string query = "insert into telefono (cod_empleado, telefono_empleado, cod_taller) " +
                    $"values ({telefono_Quito.cod_empleado}, '{telefono_Quito.telefono_empleado}', {telefono_Quito.cod_taller})";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                retorno = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return retorno;
            }
            
        }
        public static List<Telefono> mostrar_telefonos_Quito(string conexion) 
        {
            SqlConnection sqlConnection = new SqlConnection (conexion);
            sqlConnection.Open();
            List<Telefono> lista = new List<Telefono> ();
            using (sqlConnection) 
            {
                string query = "select cod_empleado, telefono_empleado, cod_taller from telefono";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Telefono telefono_Quito = new Telefono ();
                    telefono_Quito.cod_empleado = reader.GetInt32 (0);
                    telefono_Quito.telefono_empleado  =reader.GetString (1);
                    telefono_Quito.cod_taller = reader.GetInt32(2);
                    lista.Add (telefono_Quito);
                }
                sqlConnection.Close();
                return lista;
            }
        }
      
        public static int eliminar_telefono(Telefono telefono, string conexion) 
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            int retorno = 0;
            using (sqlConnection) 
            {
                string query = $"delete from telefono_Quito where cod_empleado={telefono.cod_empleado}";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                retorno = cmd.ExecuteNonQuery();
            }
            sqlConnection.Close();
            return retorno;
        }
    }
}
