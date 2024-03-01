using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;

namespace BDProyecto
{
    public class Taller
    {
        public int cod_taller { get; set; }
        public string nombre_taller { get; set; }
        public string localidad_taller { get; set; }
        public int cod_empleado { get; set; }

        public Taller() 
        {

        }
        public Taller(int cod_taller, string nombre_taller, string localidad_taller, int cod_empleado)
        {
            this.cod_taller = cod_taller;
            this.nombre_taller = nombre_taller;
            this.localidad_taller = localidad_taller;
            this.cod_empleado = cod_empleado;
        }
    }
}
