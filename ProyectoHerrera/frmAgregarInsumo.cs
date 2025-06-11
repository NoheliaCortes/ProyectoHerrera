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
    public partial class frmAgregarInsumo : Form
    {
        public frmAgregarInsumo()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAgregarInsumo_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            cmbCategoria.DataSource = categoriaNegocio.ObtenerCategorias();
            cmbCategoria.DisplayMember = "NombreCategoria";
            cmbCategoria.ValueMember = "IdCategoria";


            MedidaNegocio medidaNegocio = new MedidaNegocio();


            cmbMedida.DataSource = medidaNegocio.ObtenerMedidas();
            cmbMedida.DisplayMember = "NombreMedida";
            cmbMedida.ValueMember = "IdMedida";

        }

        public event Action InsumoAgregado;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombreInsumo = txtNombre.Text.Trim();
            int idCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
            int idMedida = Convert.ToInt32(cmbMedida.SelectedValue);

            Insumo insumo = new Insumo
            {
                NombreInsumo = nombreInsumo,
                IdCategoria = idCategoria,
                IdMedida = idMedida
            };

            InsumoNegocio insumoNegocio = new InsumoNegocio();
            if (!insumoNegocio.InsertarInsumo(insumo)) // ✅ Validación contra duplicados
            {
                MessageBox.Show("Este insumo ya existe en el sistema.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Insumo agregado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InsumoAgregado?.Invoke();
            this.Close();
        }
    }
}
