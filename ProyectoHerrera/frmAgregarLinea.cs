using BNLayer;
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
    public partial class frmAgregarLinea : Form
    {
        public event EventHandler LineaAgregada; 

        public frmAgregarLinea()
        {
            InitializeComponent();
        }

       

       

        private void frmAgregarLinea_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreLinea = txtNombreLinea.Text.Trim();

            if (!string.IsNullOrEmpty(nombreLinea))
            {
                LineaNegocio lineaNegocio = new LineaNegocio();
                lineaNegocio.AgregarLinea(nombreLinea);

                MessageBox.Show("Línea agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LineaAgregada?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un nombre válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
