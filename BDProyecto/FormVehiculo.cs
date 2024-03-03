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
    }
}
