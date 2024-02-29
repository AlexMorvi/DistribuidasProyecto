using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class Reparacion
    {
        public string placa { get; set; }
        public int cod_reparacion { get; set; }
        public string tipo_reparacion { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha_reparacion { get; set; }
        public string observaciones { get; set; }
        public Reparacion()
        {

        }
        public Reparacion(string placa, int cod_reparacion, string tipo_reparacion, decimal precio, DateTime fecha_reparacion, string observaciones)
        {
            this.placa = placa;
            this.cod_reparacion = cod_reparacion;
            this.tipo_reparacion = tipo_reparacion;
            this.precio = precio;
            this.fecha_reparacion = fecha_reparacion;
            this.observaciones = observaciones;
        }
    }   
}
