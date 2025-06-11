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
using static ProyectoHerrera.Program;

namespace ProyectoHerrera
{
    public partial class frmGestionarStock : Form
    {
        public Usuario UsuarioLogueado { get; set; } 




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
                int stockAnterior = ObtenerStockActual();


                ProductoNegocio productoNegocio = new ProductoNegocio();
                productoNegocio.AgregarStock(idProducto, cantidad);

                MessageBox.Show("Stock agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
             

                txtStockNuevo.Text = ObtenerStockActual().ToString();

                MovimientoStock movimiento = new MovimientoStock
                {
                    IdProducto = idProducto,
                    IdTipoMovimiento = 1, // ✅ "Producción"
                    IdUsuario = UsuarioLogueado.IdUsuario, // ✅ Usuario actual
                    CantidadMovida = cantidad,
                    StockAnterior = stockAnterior,
                    StockPosterior = stockAnterior + cantidad,
                    MotivoMovimiento = null 
                };

                MovimientoStockNegocio movimientoNegocio = new MovimientoStockNegocio();
                movimientoNegocio.RegistrarMovimientoStock(movimiento);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminarStock_Click_1(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(txtCantidad.Text); // ✅ Obtener la cantidad antes de abrir el formulario

            frmEliminarStock frmMotivo = new frmEliminarStock(idProducto, UsuarioLogueado.IdUsuario, cantidad);
            frmMotivo.StockEliminado += FrmMotivo_StockEliminado; // ✅ Evento para actualizar stock después
            frmMotivo.ShowDialog();
        }

        private void FrmMotivo_StockEliminado(object sender, EventArgs e)
        {
            txtStockNuevo.Text = ObtenerStockActual().ToString(); // ✅ Se actualiza el stock en `frmGestionarStock`
        }



        private void frmGestionarStock_Load(object sender, EventArgs e)
        {
            int stockActual = ObtenerStockActual();
            txtStockActual.Text = stockActual.ToString();
            txtStockNuevo.Text = "";

            UsuarioLogueado = SesionUsuario.UsuarioActual; // ✅ Se asigna el usuario logueado automáticamente



        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            StockActualizado?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
