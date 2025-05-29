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
    public partial class frmAgregarSabor : Form
    {
        private int idLinea;
        public event EventHandler SaborAgregado; 

        public frmAgregarSabor(int idLinea)
        {
            InitializeComponent();
            this.idLinea = idLinea;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmAgregarSabor_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreSabor = txtNombreSabor.Text.Trim();

            if (!string.IsNullOrEmpty(nombreSabor))
            {
                try
                {
                    SaborNegocio saborNegocio = new SaborNegocio();
                    saborNegocio.AgregarSabor(idLinea, nombreSabor);

                    MessageBox.Show("Sabor agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SaborAgregado?.Invoke(this, EventArgs.Empty); // ✅ Notificar que se agregó un sabor
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un nombre válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    
}
