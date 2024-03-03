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
    public partial class FormTelefono : Form
    {
        private string conexion;
        public FormTelefono(string conexion)
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

        private void FormEmpleado_Load(object sender, EventArgs e)
        {
            refressPantalla();
        }

        public void refressPantalla()
        {
            dataGridView1.DataSource = TelefonoData.mostrar_telefonos(conexion);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int cod_empleado = int.Parse(txtCodEmpl.Text);
            string telefono_empleado = txtTelfEmpl.Text;
            int cod_taller = int.Parse(txtCodTaller.Text);
           
            Telefono telefono = new Telefono(cod_empleado, telefono_empleado, cod_taller);
            TelefonoData.insertar_telefono(telefono, this.conexion);
            refressPantalla();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtTelfEmpl.Clear();
            txtCodTaller.Clear();
            txtCodEmpl.Clear();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int cod_empleado = int.Parse(txtCodEmpl.Text);
            string telefono_empleado = txtTelfEmpl.Text;
            int cod_taller = int.Parse(txtCodTaller.Text);

            Telefono telefono = new Telefono(cod_empleado, telefono_empleado, cod_taller);
            TelefonoData.eliminar_telefono(telefono, this.conexion);
            refressPantalla();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtTelfEmpl.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["telefono_empleado"].Value);
            txtCodTaller.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["cod_taller"].Value);
            txtCodEmpl.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["cod_empleado"].Value);
        }
    }
}
