using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class TallerData
    {

        public static List<Taller> mostrar_talleres(string conexion) 
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            List<Taller> lista = new List<Taller> ();
            using (sqlConnection) 
            {
                string query = "select cod_taller, nombre_taller, localidad_taller, cod_empleado from taller";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    Taller taller_Quito = new Taller();
                    taller_Quito.cod_taller = reader.GetInt32 (0);
                    taller_Quito.nombre_taller = reader.GetString (1);
                    taller_Quito.localidad_taller = reader.GetString(2);
                    taller_Quito.cod_empleado = reader.GetInt32(3);
                    lista.Add(taller_Quito);
                }
                sqlConnection.Close();
                return lista;
            }
        }
       
    }
}
