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
        private string conexion;
        public FormCliente(string conexion)
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

        private void FormCliente_Load(object sender, EventArgs e)
        {
            refressPantalla();
        }

        public void refressPantalla()
        {
            dataGridView1.DataSource = ClienteData.mostrar_clientes(conexion);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre_cliente = txtNombre.Text;
            string apellido_cliente = txtApellido.Text;
            int cod_taller = int.Parse(txtCodTaller.Text);
            string cedula_cliente = txtCedula.Text;
            string ciudad_residencia = txtCiudad.Text;
            string telefono = txtTelefono.Text;
            Cliente cliente = new Cliente(nombre_cliente, apellido_cliente, cod_taller, cedula_cliente, ciudad_residencia, telefono);
            ClienteData.insertar_cliente(cliente, conexion);
        }
    }
}
