using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDProyecto
{
    public partial class FormReparacion : Form
    {
        private string conexion;
        public FormReparacion(string conexion)
        {
            this.conexion = conexion;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void FormReparacion_Load(object sender, EventArgs e)
        {
            refressPantalla();
        }
        public void refressPantalla()
        {
            dataGridViewReparacion.DataSource = ReparacionData.mostrar_reparacion(conexion);
        }
    }
}
