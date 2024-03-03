﻿using System;
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
    public partial class FormEmpleado : Form
    {
        private string conexion;
        public FormEmpleado(string conexion)
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
            dataGridView1.DataSource = EmpleadoData.mostrar_empleados(conexion);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string cedula = txtCedula.Text;
            DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text);
            decimal salario = decimal.Parse(txtSalario.Text);
            int cod_empleado = int.Parse(txtCodEmpleado.Text);
            int cod_taller = int.Parse(txtCodTaller.Text);
            Empleado empleado = new Empleado(cod_empleado, cod_taller, cedula, nombre, apellido, salario, fechaInicio);
            EmpleadoData.insertar_empleado(empleado, this.conexion);
            refressPantalla();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtCedula.Clear();
            txtCodEmpleado.Clear();
            txtCodTaller.Clear();
            txtFechaInicio.Clear();
            txtNombre.Clear();
            txtSalario.Clear();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string cedula = txtCedula.Text;
            DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text);
            decimal salario = decimal.Parse(txtSalario.Text);
            int cod_empleado = int.Parse(txtCodEmpleado.Text);
            int cod_taller = int.Parse(txtCodTaller.Text);
            Empleado empleado = new Empleado(cod_empleado, cod_taller, cedula, nombre, apellido, salario, fechaInicio);
            EmpleadoData.actualizar_empleado(empleado, this.conexion);
            refressPantalla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string cedula = txtCedula.Text;
            DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text);
            decimal salario = decimal.Parse(txtSalario.Text);
            int cod_empleado = int.Parse(txtCodEmpleado.Text);
            int cod_taller = int.Parse(txtCodTaller.Text);
            Empleado empleado = new Empleado(cod_empleado, cod_taller, cedula, nombre, apellido, salario, fechaInicio);
            EmpleadoData.eliminar_empleado(empleado, this.conexion);

            refressPantalla();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtApellido.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["apellido_empleado"].Value);
            txtCedula.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["cedula_empleado"].Value);
            txtCodEmpleado.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["cod_empleado"].Value);
            txtCodTaller.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["cod_taller"].Value);
            txtFechaInicio.Text = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["fecha_inicio"].Value).ToString("yyyy/MM/dd");
            txtNombre.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre_empleado"].Value);
            txtSalario.Text = Convert.ToString(Math.Floor(Convert.ToDecimal(dataGridView1.CurrentRow.Cells["salario"].Value)));
        }
    }
}
