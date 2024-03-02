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
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            refressPantalla();
        }

        public void refressPantalla()
        {

            Conexion conexion = new Conexion("BD-QUITO", "QuitoTaller", "sa", "P@ssw0rd");
            dataGridView1.DataSource = ClienteData.mostrar_clientes(conexion);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
