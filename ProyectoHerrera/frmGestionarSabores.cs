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
    public partial class frmGestionarSabores : Form
    {

        private int idSaborSeleccionado;
        private string nombreSaborSeleccionado;

        private int idLinea;
        private string nombreLinea;

       
        public frmGestionarSabores(int idLinea, string nombreLinea)
        {
            InitializeComponent();
            this.idLinea = idLinea;
            this.nombreLinea = nombreLinea;

            lblLineaSeleccionada.Text = $"Sabores de la línea: {nombreLinea}"; 
            CargarSabores(); 
        }

        private void CargarSabores()
        {
            SaborNegocio saborNegocio = new SaborNegocio();
            dgvSabores.DataSource = saborNegocio.ObtenerSaboresPorLinea(idLinea); 
        }





        private void frmGestionarSabores_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSaborSeleccionado > 0) 
            {
                DialogResult confirmacion = MessageBox.Show($"¿Eliminar el sabor '{nombreSaborSeleccionado}'?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    SaborNegocio saborNegocio = new SaborNegocio();

                    if (saborNegocio.EliminarSabor(idSaborSeleccionado))
                    {
                        MessageBox.Show("Sabor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarSabores();
                        idSaborSeleccionado = 0; 
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar este sabor porque está en productos registrados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un sabor antes de eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarSabor frm = new frmAgregarSabor(idLinea);
            frm.SaborAgregado += (s, args) => CargarSabores(); 
            frm.ShowDialog();
        }

        private void dgvSabores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSabores_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                idSaborSeleccionado = Convert.ToInt32(dgvSabores.Rows[e.RowIndex].Cells["id_sabor"].Value);
                nombreSaborSeleccionado = dgvSabores.Rows[e.RowIndex].Cells["nombre_sabor"].Value.ToString();



            }
        }
    }
}
