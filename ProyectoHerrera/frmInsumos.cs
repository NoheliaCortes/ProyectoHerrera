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
    public partial class frmInsumos : Form
    {


            private InsumoNegocio insumoNegocio = new InsumoNegocio();
        private CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        public frmInsumos()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            frmAgregarInsumo agregarInsumoForm = new frmAgregarInsumo();
            agregarInsumoForm.InsumoAgregado += CargarInsumosConCategoria; 
            agregarInsumoForm.ShowDialog();
        }

        private void CargarInsumosConCategoria()
        {
            List <InsumoConCategoria> lista = insumoNegocio.ObtenerInsumosConCategoria();
            dgvInsumos.DataSource = lista;
            CargarCategorias();

        }

        private void frmInsumos_Load(object sender, EventArgs e)
        {
            CargarInsumosConCategoria();
        }

        private void btnGestionarStockInsumo_Click(object sender, EventArgs e)
        {
            if (dgvInsumos.SelectedRows.Count > 0)
            {
                int idInsumo = Convert.ToInt32(dgvInsumos.SelectedRows[0].Cells["idInsumo"].Value);
                string nombreInsumo = dgvInsumos.SelectedRows[0].Cells["NombreInsumo"].Value.ToString();
                int stockActual = Convert.ToInt32(dgvInsumos.SelectedRows[0].Cells["stock"].Value);

                frmGestionarStockInsumo gestionarStockForm = new frmGestionarStockInsumo(idInsumo, nombreInsumo, stockActual);
                gestionarStockForm.StockActualizado += CargarInsumosConCategoria; 
                gestionarStockForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecciona un insumo antes de gestionar el stock.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarCategorias()
        {
            dgvCategorias.DataSource = categoriaNegocio.ObtenerCategorias();
        }

    }
}
