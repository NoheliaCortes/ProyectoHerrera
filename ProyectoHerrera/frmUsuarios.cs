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

namespace ProyectoHerrera
{
    public partial class frmUsuarios : Form
    {

        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btnRegistrarUsuarios_Click(object sender, EventArgs e)
        {
            frmRegistrarUsuario frm = new frmRegistrarUsuario();
            frm.ShowDialog();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }


        public void CargarUsuarios()
        {
            List<Usuario> lista = usuarioNegocio.ObtenerUsuarios();
            dgvUsuarios.DataSource = lista;



        }
    }
}
