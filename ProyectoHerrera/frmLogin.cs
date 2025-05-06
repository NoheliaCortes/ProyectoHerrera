using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoHerrera
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.AcceptButton = btnIngresas; // Establecer el botón de inicio de sesión como el botón predeterminado
        }

       

        private void btnIngresas_Click(object sender, EventArgs e)
        {
            if (txtUsuario .Text == "admin" && txtContraseña.Text == "123" )
            {
                frmInicio frminicio = new frmInicio();
                frminicio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Los datos ingresados son incorrectos.");
                // Limpiar los campos de texto
                txtUsuario.Clear();
                txtContraseña.Clear();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private bool ShowPassword = false; //variable de control para mostrar y ocultar la conraseña
        private void pbContraseña_Click(object sender, EventArgs e)
        {
            ShowPassword = !ShowPassword;
            if (ShowPassword)
            {
                txtContraseña.PasswordChar = '\0';
                pbContraseña.Image = ProyectoHerrera.Properties.Resources.hide;

            }
            else
            {
                txtContraseña.PasswordChar = '*';
                pbContraseña.Image = ProyectoHerrera.Properties.Resources.show;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
