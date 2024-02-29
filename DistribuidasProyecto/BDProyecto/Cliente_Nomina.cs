using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{

    public class Cliente_Nomina
    {
        public string nombre_cliente { get; set; }
        public string apellido_cliente { get; set; }
        public Cliente_Nomina(){}
        public Cliente_Nomina(string nombre_cliente, string apellido_cliente)
        {
            this.nombre_cliente = nombre_cliente;
            this.apellido_cliente = apellido_cliente;

        }

    }
       
}
