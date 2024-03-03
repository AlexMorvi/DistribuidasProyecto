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
            int cod_taller = int.Parse(txtCodTaller.Text);
            int cod_reparacion = int.Parse(txtCodReparacion.Text);
            string placa= txtPlaca.Text;
            string tipo = txtTipoReparacion.Text;
            decimal precio = decimal.Parse(txtPrecio.Text);
            DateTime fecha = DateTime.Parse(txtFecha.Text);
            string observaciones = txtObservaciones.Text;
            Reparacion reparacion = new Reparacion(placa,cod_reparacion,cod_taller,tipo,precio,fecha,observaciones);
            ReparacionData.insertar_reparacion(reparacion, this.conexion);
            refressPantalla();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtCodReparacion.Clear();
            txtCodTaller.Clear();
            txtPlaca.Clear();
            txtTipoReparacion.Clear();
            txtPrecio.Clear();
            txtFecha.Clear();
            txtObservaciones.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int cod_taller = int.Parse(txtCodTaller.Text);
            int cod_reparacion = int.Parse(txtCodReparacion.Text);
            string placa = txtPlaca.Text;
            string tipo = txtTipoReparacion.Text;
            decimal precio = decimal.Parse(txtPrecio.Text);
            DateTime fecha = DateTime.Parse(txtFecha.Text);
            string observaciones = txtObservaciones.Text;
            Reparacion reparacion = new Reparacion(placa, cod_reparacion, cod_taller, tipo, precio, fecha, observaciones);
            ReparacionData.actualizar_datos_reparacion_Quito(reparacion, this.conexion);
            refressPantalla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int cod_taller = int.Parse(txtCodTaller.Text);
            int cod_reparacion = int.Parse(txtCodReparacion.Text);
            string placa = txtPlaca.Text;
            string tipo = txtTipoReparacion.Text;
            decimal precio = decimal.Parse(txtPrecio.Text);
            DateTime fecha = DateTime.Parse(txtFecha.Text);
            string observaciones = txtObservaciones.Text;
            Reparacion reparacion = new Reparacion(placa, cod_reparacion, cod_taller, tipo, precio, fecha, observaciones);
            ReparacionData.eliminar_reparacion_Quito(reparacion, this.conexion);
            refressPantalla();
        }

        private void FormReparacion_Load(object sender, EventArgs e)
        {
            refressPantalla();
        }
        public void refressPantalla()
        {
            dataGridViewReparacion.DataSource = ReparacionData.mostrar_reparacion(conexion);
        }

        private void dataGridViewReparacion_SelectionChanged(object sender, EventArgs e)
        {
            txtCodReparacion.Text = Convert.ToString(dataGridViewReparacion.CurrentRow.Cells["cod_reparacion"].Value);
            txtCodTaller.Text = Convert.ToString(dataGridViewReparacion.CurrentRow.Cells["cod_taller"].Value);
            txtPlaca.Text = Convert.ToString(dataGridViewReparacion.CurrentRow.Cells["placa"].Value);
            txtTipoReparacion.Text = Convert.ToString(dataGridViewReparacion.CurrentRow.Cells["tipo_reparacion"].Value);
            txtPrecio.Text = Convert.ToString(dataGridViewReparacion.CurrentRow.Cells["precio"].Value);
            txtFecha.Text = Convert.ToString(dataGridViewReparacion.CurrentRow.Cells["fecha_reparacion"].Value);
            txtObservaciones.Text = Convert.ToString(dataGridViewReparacion.CurrentRow.Cells["observaciones"].Value);

        }
    }
}
