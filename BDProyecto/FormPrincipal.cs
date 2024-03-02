using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace BDProyecto
{
    public partial class FormPrincipal : Form
    {
        private string conexion;

        public FormPrincipal(string conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (menuVertical.Width == 246)
            {
                menuVertical.Width = 76;
            }
            else
            {
                menuVertical.Width = 246;
            }
        }
        
        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormEmpleado());
        }

        private void AbrirFormInPanel(object formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormCliente(this.conexion));
        }

        private void btnVehiculo_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormVehiculo());
        }

        private void btnTaller_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormTaller());
        }

        private void btnReparacion_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormReparacion());
        }
    }
}
