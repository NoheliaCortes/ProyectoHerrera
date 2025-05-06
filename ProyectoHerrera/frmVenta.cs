using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BNLayer;

namespace ProyectoHerrera
{
    public partial class frmVenta : Form
    {
        public frmVenta()
        {
            InitializeComponent();
            this.Load += frmVenta_Load;
        }
        private void frmVenta_Load(object sender, EventArgs e)
        {

            //txtFactura.Text = ObtenerSiguienteFactura().ToString();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtHora.Text = DateTime.Now.ToString("HH:mm:ss");
           

            LineaNegocio lineaNegocio = new LineaNegocio();
            cmbLinea.DataSource = lineaNegocio.ObtenerLineas();
            cmbLinea.DisplayMember = "nombre_linea";
            cmbLinea.ValueMember = "IdLinea";



        }

        private void cmbLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idLinea = Convert.ToInt32(cmbLinea.SelectedValue);

            SaborNegocio saborNegocio = new SaborNegocio();
            cmbSabor.DataSource = saborNegocio.ObtenerSaboresPorLinea(idLinea);
            cmbSabor.DisplayMember = "nombre_sabor";
            cmbSabor.ValueMember = "id_sabor";
        }

        private void cmbSabor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSabor = Convert.ToInt32(cmbSabor.SelectedValue);

            MedidaNegocio medidaNegocio = new MedidaNegocio();
            cmbMedida.DataSource = medidaNegocio.ObtenerMedidasPorSabor(idSabor);
            cmbMedida.DisplayMember = "nombre_medida";
            cmbMedida.ValueMember = "id_medida";
        }

        private void cmbMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMedida = Convert.ToInt32(cmbMedida.SelectedValue);

            PesoNegocio pesoNegocio = new PesoNegocio();
            cmbPeso.DataSource = pesoNegocio.ObtenerPesosPorMedida(idMedida);
            cmbPeso.DisplayMember = "nombre_peso";
            cmbPeso.ValueMember = "id_peso";
        }

        private void cmbPeso_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idLinea = Convert.ToInt32(cmbLinea.SelectedValue);
            int idSabor = Convert.ToInt32(cmbSabor.SelectedValue);
            int idMedida = Convert.ToInt32(cmbMedida.SelectedValue);
            int idPeso = Convert.ToInt32(cmbPeso.SelectedValue);

            ProductoNegocio productoNegocio = new ProductoNegocio();
            dgvProductos.DataSource = productoNegocio.ObtenerProductoPorFiltros(idLinea, idSabor, idMedida, idPeso);

            // Configurar las columnas del DataGridView
            dgvProductos.Columns["nombre_producto"].HeaderText = "Producto";
            dgvProductos.Columns["precio_producto"].HeaderText = "Precio";
            dgvProductos.Columns["descuento_producto"].HeaderText = "Descuento";
        }






















       







        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
