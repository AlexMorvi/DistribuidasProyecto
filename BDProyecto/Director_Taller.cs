using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class Director_Taller
    {
        public int cod_taller { get; set; }
        public int cod_empleado { get; set; }
        public Director_Taller()
        {

        }
        public Director_Taller(string nombre_cliente, string apellido_cliente, int cod_taller, string cedula_cliente, string ciudad_residencia, string telefono)
        {
            
            this.cod_taller = cod_taller;
            this.cod_empleado = cod_empleado;

        }

    }
}