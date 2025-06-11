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
    public partial class frmCompra : Form
    {
        public frmCompra()
        {
            InitializeComponent();
        }

        private void frmCompra_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            CargarCategorias();
            txtTotal.Text = "0.00";

            dgvInsumos.Columns.Add("NombreInsumo", "Insumo");
            dgvInsumos.Columns.Add("UnidadMedida", "Unidad de Medida");
            dgvInsumos.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvInsumos.Columns.Add("Cantidad", "Cantidad");
            dgvInsumos.Columns.Add("Subtotal", "Subtotal"); // ✅ Nueva columna




        }

        private CompraNegocio compraNegocio = new CompraNegocio();
        private ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
        private InsumoNegocio insumoNegocio = new InsumoNegocio();
        private CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        

        private List<DetalleCompra> detallesCompra = new List<DetalleCompra>(); // ✅ Lista de detalles

      

        

        private void CargarProveedores()
        {
            cmbProveedor.DataSource = proveedorNegocio.ObtenerProveedores();
            cmbProveedor.DisplayMember = "nombre";
            cmbProveedor.ValueMember = "Id_Proveedor";
            cmbProveedor.SelectedIndex = 0;
        }

        private void CargarCategorias()
        {
            cmbCategoria.DataSource = categoriaNegocio.ObtenerCategorias();
            cmbCategoria.DisplayMember = "NombreCategoria";
            cmbCategoria.ValueMember = "IdCategoria";
            cmbCategoria.SelectedIndex = 0;
        }

 

        private void CargarInsumosPorCategoria(int idCategoria)
        {
            cmbInsumo.DataSource = insumoNegocio.ObtenerInsumosPorCategoria(idCategoria);
            cmbInsumo.DisplayMember = "NombreInsumo";
            cmbInsumo.ValueMember = "IdInsumo";
            cmbInsumo.SelectedIndex = 0;
        }

       

        private void ActualizarTotal()
        {
            decimal total = detallesCompra.Sum(d => d.Cantidad * d.PrecioUnitario);
            txtTotal.Text = total.ToString("0.00"); // ✅ Formateamos a dos decimales
        }

        
    

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingresa una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal precioUnitario;
            if (!decimal.TryParse(txtPrecio.Text, out precioUnitario) || precioUnitario <= 0)
            {
                MessageBox.Show("Ingresa un precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idInsumo = Convert.ToInt32(cmbInsumo.SelectedValue);
            string nombreInsumo = cmbInsumo.Text;
            string unidadMedida = insumoNegocio.ObtenerMedidaInsumo(idInsumo); // ✅ Obtener unidad de medida

            decimal subtotal = cantidad * precioUnitario;

            DetalleCompra detalle = new DetalleCompra
            {
                IdInsumo = idInsumo,
                Cantidad = cantidad,
                PrecioUnitario = precioUnitario
            };

            detallesCompra.Add(detalle); // ✅ Agregar al listado de detalles

            dgvInsumos.Rows.Add(nombreInsumo, unidadMedida, precioUnitario, cantidad, subtotal); // ✅ Mostrar en `DataGridView`

            ActualizarTotal();
        }

        private void btnRegistrarCompra_Click_1(object sender, EventArgs e)
        {
            if (detallesCompra.Count == 0)
            {
                MessageBox.Show("Agrega al menos un insumo a la compra.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Compra compra = new Compra
            {
                IdProveedor = Convert.ToInt32(cmbProveedor.SelectedValue),
                Fecha = DateTime.Now,
                Total = Convert.ToDecimal(txtTotal.Text),
                Detalles = detallesCompra
            };

            if (compraNegocio.RegistrarCompra(compra))
            {
                MessageBox.Show("¡Compra registrada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvInsumos.Rows.Clear();
                detallesCompra.Clear();
                txtTotal.Text = "0.00"; // ✅ Reiniciar total
            }
            else
            {
                MessageBox.Show("Error al registrar la compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LimpiarCampos();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedValue != null) // ✅ Evita valores `null`
            {
                int idCategoria;
                if (int.TryParse(cmbCategoria.SelectedValue.ToString(), out idCategoria))
                {
                    CargarInsumosPorCategoria(idCategoria); // ✅ Filtra insumos correctamente
                }
            }
        }

        private void LimpiarCampos()
        {
            cmbProveedor.SelectedIndex = 0; 
            cmbCategoria.SelectedIndex = 0; 
            cmbInsumo.SelectedIndex = -1; 

            txtCantidad.Clear(); 
            txtPrecio.Clear(); 
            txtTotal.Text = "0.00"; 

            dgvInsumos.Rows.Clear(); 
            detallesCompra.Clear(); 
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            frmHistorialCompras frm = new frmHistorialCompras();
            frm.ShowDialog();
        }
    }
}
