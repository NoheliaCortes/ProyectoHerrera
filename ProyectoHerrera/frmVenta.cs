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
using DataLayer.Modelos;

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

           
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtHora.Text = DateTime.Now.ToString("HH:mm:ss");

         
            LineaNegocio lineaNegocio = new LineaNegocio();
            cmbLinea.DataSource = lineaNegocio.ObtenerLineas();
            cmbLinea.DisplayMember = "NombreLinea";
            cmbLinea.ValueMember = "IdLinea"; 

            
            SaborNegocio saborNegocio = new SaborNegocio();
            cmbSabor.DisplayMember = "nombre_sabor";
            cmbSabor.ValueMember = "id_sabor"; 
            cmbSabor.Enabled = false;

         
            MedidaNegocio medidaNegocio = new MedidaNegocio();
            cmbMedida.DataSource = medidaNegocio.ObtenerMedidas();
            cmbMedida.DisplayMember = "NombreMedida";
            cmbMedida.ValueMember = "IdMedida";

           
            PesoNegocio pesoNegocio = new PesoNegocio();
            cmbPeso.DataSource = pesoNegocio.ObtenerPesos();
            cmbPeso.DisplayMember = "NombrePeso";
            cmbPeso.ValueMember = "IdPeso";

            cmbSabor.Enabled = false;
            cmbMedida.Enabled = true;
            cmbPeso.Enabled = true;

            ClienteNegocio clienteNegocio = new ClienteNegocio();
            List<Cliente> clientes = clienteNegocio.ObtenerClientes();

            cmbCliente.DataSource = clientes;
            cmbCliente.DisplayMember = "Nombre"; 
            cmbCliente.ValueMember = "IdCliente"; 

            
            cmbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
        }


        

        private void cmbLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLinea.SelectedItem is Linea lineaSeleccionada)
            {
                int idLinea = lineaSeleccionada.IdLinea; 
                cmbSabor.Enabled = true;

                SaborNegocio saborNegocio = new SaborNegocio();
                cmbSabor.DataSource = saborNegocio.ObtenerSaboresPorLinea(idLinea); 
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }

            txtTotal.Text = total.ToString("F2"); 
        }






        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbLinea.SelectedItem == null || cmbSabor.SelectedValue == null ||
         cmbMedida.SelectedItem == null || cmbPeso.SelectedItem == null ||
         string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Por favor, llena todos los campos antes de agregar el producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Por favor, ingresa una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            int idLinea = ((Linea)cmbLinea.SelectedItem).IdLinea; 
            int idSabor = Convert.ToInt32(cmbSabor.SelectedValue); 
            int idMedida = ((Medida)cmbMedida.SelectedItem).IdMedida; 
            int idPeso = ((Peso)cmbPeso.SelectedItem).IdPeso; 

            ProductoNegocio productoNegocio = new ProductoNegocio();
            DataTable dtProducto = productoNegocio.BuscarProductoConDescuento(idLinea, idSabor, idMedida, idPeso);

            if (dtProducto.Rows.Count > 0)
            {
                DataRow row = dtProducto.Rows[0];
                string nombreProducto = row["nombre_producto"].ToString();
                decimal precio = Convert.ToDecimal(row["precio_producto"]);
                decimal descuento = Convert.ToDecimal(row["descuento_producto"]);
                int cantidadMinima = Convert.ToInt32(row["cantidad_minima_descuento"]);

                if (cantidad >= cantidadMinima)
                {
                    descuento = cantidad * descuento;
                }
                else
                {
                    descuento = 0m;
                }

                decimal subtotal = (cantidad * precio) - descuento;

                dgvProductos.Rows.Add(nombreProducto, cantidad, precio, descuento, subtotal);
                CalcularTotal();
            }
            else
            {
                MessageBox.Show("El producto no existe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTotal.Text, out decimal total) || !decimal.TryParse(txtPago.Text, out decimal pago))
            {
                MessageBox.Show("Por favor, ingresa un pago válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pago < total)
            {
                MessageBox.Show("El pago es menor al total. Ingresa un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal cambio = pago - total;
            txtCambio.Text = cambio.ToString("F2");
        }
    }
}
