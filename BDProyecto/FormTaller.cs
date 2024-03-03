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
    public partial class FormTaller : Form
    {
        private string conexion;
        public FormTaller(string conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
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

        private void label6_Click(object sender, EventArgs e)
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

        private void FormTaller_Load(object sender, EventArgs e)
        {
            refressPantalla();
        }
        public void refressPantalla()
        {
            dataGridViewTaller.DataSource = TallerData.mostrar_talleres(this.conexion);
        }
    }
}
