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
    public partial class FormVehiculo : Form
    {
        private string conexion;
        public FormVehiculo(string conexion)
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
            string placa = txtPlaca.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int cod_taller = int.Parse(txtCodigoTaller.Text);
            string num_matricula = txtNumMatricula.Text;
            DateTime fecha_compra = DateTime.Parse(txtFechaCompra.Text);
            Vehiculo vehiculo = new Vehiculo(placa, nombre, apellido, cod_taller, num_matricula, fecha_compra);
            VehiculoData.insertar_vehiculo_Quito(vehiculo, this.conexion);
            refressPantalla();

        }
        private void FormVehiculo_Load(object sender, EventArgs e)
        {
            refressPantalla();
        }

        public void refressPantalla()
        {
            dataGridView1.DataSource = VehiculoData.mostrar_vehiculos(conexion);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtCodigoTaller.Clear();
            txtFechaCompra.Clear();
            txtNombre.Clear();
            txtNumMatricula.Clear();
            txtPlaca.Clear();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int cod_taller = int.Parse(txtCodigoTaller.Text);
            string num_matricula = txtNumMatricula.Text;
            DateTime fecha_compra = DateTime.Parse(txtFechaCompra.Text);
            Vehiculo vehiculo = new Vehiculo(placa, nombre, apellido, cod_taller, num_matricula, fecha_compra);
            VehiculoData.actualizar_vehiculos_Quito(vehiculo, this.conexion);

            refressPantalla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int cod_taller = int.Parse(txtCodigoTaller.Text);
            string num_matricula = txtNumMatricula.Text;
            DateTime fecha_compra = DateTime.Parse(txtFechaCompra.Text);
            Vehiculo vehiculo = new Vehiculo(placa, nombre, apellido, cod_taller, num_matricula, fecha_compra);
            VehiculoData.eliminar_vehiculo_Quito(vehiculo, this.conexion);
            refressPantalla();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtApellido.Text = dataGridView1.CurrentRow.Cells["apellido_cliente"].Value.ToString();
            txtCodigoTaller.Text = dataGridView1.CurrentRow.Cells["cod_taller"].Value.ToString();
            txtFechaCompra.Text = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["fecha_compra"].Value).ToString("yyyy/MM/dd");
            txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre_cliente"].Value.ToString();
            txtNumMatricula.Text = dataGridView1.CurrentRow.Cells["num_matricula"].Value.ToString();
            txtPlaca.Text = dataGridView1.CurrentRow.Cells["placa"].Value.ToString();

        }
    }
}
