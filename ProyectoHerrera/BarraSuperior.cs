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
    public partial class BarraSuperior : UserControl
    {

        
        public BarraSuperior()
        {
            InitializeComponent();

            if (SesionUsuario.UsuarioActual != null)
            {
                lblNombreUsuario.Text = $"{SesionUsuario.UsuarioActual.NombreUsuario} {SesionUsuario.UsuarioActual.ApellidoUsuario}";
            }

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Form frmActual = this.FindForm();

            
           

            
            if (frmActual != null && frmActual.Name != "frmInicio")
            {
                frmActual.Close();
            }
         }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
