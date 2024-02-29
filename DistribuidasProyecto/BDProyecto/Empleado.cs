using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class Empleado
    {
        public int cod_empleado { get; set; }
        public int cod_taller { get; set; }
        public string nombre_empleado { get; set; }
        public string apellido_empleado { get; set; }
        public string cedula_empleado { get; set; }
        public decimal salario { get; set; }
        public DateTime fecha_inicio { get; set; }
        public Empleado()
        {

        }
        public Empleado(string nombre_empleado, string apellido_empleado, int cod_empleado, string cedula_empleado, decimal salario, DateTime fecha_inicio)
        {
            this.cod_empleado = cod_empleado;
            this.nombre_empleado = nombre_empleado;
            this.apellido_empleado = apellido_empleado;
            this.cod_taller = cod_taller;
            this.cedula_empleado = cedula_empleado;
            this.salario = salario;
            this.fecha_inicio = fecha_inicio;

        }

    }
}
