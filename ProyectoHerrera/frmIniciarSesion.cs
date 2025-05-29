using BNLayer;
using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoHerrera.Program;


namespace ProyectoHerrera
{
    public partial class frmIniciarSesion : Form
    {

        


        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        public frmIniciarSesion()
        {
            InitializeComponent();
        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }

      

        private void btnIniciarSesion_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Por favor, ingresa tu correo y contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            Usuario usuario = usuarioNegocio.ObtenerUsuarioPorCorreo(txtCorreo.Text.Trim());

            if (usuario != null) 
            {
                
                if (BCrypt.Net.BCrypt.Verify(txtClave.Text.Trim(), usuario.Clave))
                {
                    MessageBox.Show($"¡Bienvenido, {usuario.NombreUsuario}!", "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    

                    SesionUsuario.UsuarioActual = usuario;  // ✅ Guardar usuario globalmente tras login

                    frmInicio frm = new frmInicio();
                   
                    frm.Show();
                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta. Inténtalo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Usuario no encontrado. Verifica el correo ingresado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmIniciarSesion_Load(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = true;
        }
    }
}
