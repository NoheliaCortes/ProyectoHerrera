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
    public partial class frmGestionarStock : Form
    {
        private int idProducto;
        private string nombreProducto;
       
        public event EventHandler StockActualizado;

        public frmGestionarStock(int idProducto, string nombreProducto)
        {
            InitializeComponent();
            this.idProducto = idProducto;
            this.nombreProducto = nombreProducto;
            

            txtProductoSeleccionado.Text = $"{nombreProducto}";

            txtStockNuevo.Text = ObtenerStockActual().ToString();
        }

        private int ObtenerStockActual()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            return productoNegocio.ObtenerStockActual(idProducto);
        }





        private void btnAgregarStock_Click_1(object sender, EventArgs e)
        {
            try
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);

                ProductoNegocio productoNegocio = new ProductoNegocio();
                productoNegocio.AgregarStock(idProducto, cantidad);

                MessageBox.Show("Stock agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
             

                txtStockNuevo.Text = ObtenerStockActual().ToString();

              

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminarStock_Click_1(object sender, EventArgs e)
        {
            try
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);

                ProductoNegocio productoNegocio = new ProductoNegocio();
                productoNegocio.EliminarStock(idProducto, cantidad);

                MessageBox.Show("Stock eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                txtStockNuevo.Text = ObtenerStockActual().ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmGestionarStock_Load(object sender, EventArgs e)
        {
            int stockActual = ObtenerStockActual();
            txtStockActual.Text = stockActual.ToString();
            txtStockNuevo.Text = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            StockActualizado?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
