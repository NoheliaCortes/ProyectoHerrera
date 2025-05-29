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
using BCrypt.Net;

namespace ProyectoHerrera
{
    public partial class frmRegistrarUsuario : Form
    {


        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        public frmRegistrarUsuario()
        {
            InitializeComponent();
        }
        private void frmRegistrarUsuario_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }


        private void CargarRoles()
        {
            RolNegocio rolNegocio = new RolNegocio(); 
            List<Rol> roles = rolNegocio.ObtenerRoles(); 

            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "TipoRol"; 
            cmbRol.ValueMember = "IdRol"; 
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text)||
       string.IsNullOrWhiteSpace(txtClave.Text) || string.IsNullOrWhiteSpace(txtConfirmarClave.Text) ||
       cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Validar que las contraseñas coincidan
            if (txtClave.Text.Trim() != txtConfirmarClave.Text.Trim())
            {
                MessageBox.Show("Las contraseñas no coinciden. Verifica e inténtalo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ✅ Obtener datos del formulario
            Usuario usuario = new Usuario
            {
                NombreUsuario = txtNombre.Text.Trim(),
                ApellidoUsuario = txtApellido.Text.Trim(),
                Clave = BCrypt.Net.BCrypt.HashPassword(txtClave.Text.Trim()), // 🔒 Hash de la clave
                IdRol = Convert.ToInt32(cmbRol.SelectedValue),
                Estado = chkEstado.Checked,
                Correo = txtCorreo.Text.Trim()
            };

            


            if (usuarioNegocio.RegistrarUsuario(usuario))
            {
                MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al registrar usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtClave.Clear();
            txtConfirmarClave.Clear();
            txtCorreo.Clear();
            cmbRol.SelectedIndex = -1;
            chkEstado.Checked = false;
        }
    }
}
