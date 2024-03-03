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
            
            //txtNombre.Enabled = false;
            //txtApellido.Enabled = false;
            //txtCedula.Enabled = false;
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
            refressPantalla();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
                txtNombre.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre_cliente"].Value);
                txtApellido.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["apellido_cliente"].Value);
                txtCodTaller.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["cod_taller"].Value);
                txtCedula.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["cedula_cliente"].Value);
                txtCiudad.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ciudad_residencia"].Value);
                txtTelefono.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["telefono"].Value);

            
        }

        private void txtLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtCedula.Clear();
            txtCiudad.Clear();
            txtCodTaller.Clear();
            txtTelefono.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string nombre_cliente = txtNombre.Text;
            string apellido_cliente = txtApellido.Text;
            int cod_taller = int.Parse(txtCodTaller.Text);
            string cedula_cliente = txtCedula.Text;
            string ciudad_residencia = txtCiudad.Text;
            string telefono = txtTelefono.Text;
            Cliente cliente = new Cliente(nombre_cliente, apellido_cliente, cod_taller, cedula_cliente, ciudad_residencia, telefono);
            ClienteData.actualizar_datos_cliente(cliente, conexion);
            refressPantalla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string nombre_cliente = txtNombre.Text;
            string apellido_cliente = txtApellido.Text;
            int cod_taller = int.Parse(txtCodTaller.Text);
            string cedula_cliente = txtCedula.Text;
            string ciudad_residencia = txtCiudad.Text;
            string telefono = txtTelefono.Text;
            Cliente cliente = new Cliente(nombre_cliente, apellido_cliente, cod_taller, cedula_cliente, ciudad_residencia, telefono);
            ClienteData.eliminar_cliente(cliente, conexion);
            refressPantalla();
        }
    }
}
