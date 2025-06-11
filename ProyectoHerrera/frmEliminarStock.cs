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
    public partial class frmEliminarStock : Form
    {
        private int idProducto;
        private int idUsuario;
        private int cantidad; // ✅ Variable para la cantidad enviada desde `frmGestionarStock`
        public event EventHandler StockEliminado; // ✅ Notifica a `frmGestionarStock` después de eliminar

        public frmEliminarStock(int idProducto, int idUsuario, int cantidad)
        {
            InitializeComponent();
            this.idProducto = idProducto;
            this.idUsuario = idUsuario;
            this.cantidad = cantidad; // ✅ Guardamos la cantidad recibida
            
        }

        private void CargarMotivos()
        {
            cmbMotivoMovimiento.Items.Add("Pérdida");
            cmbMotivoMovimiento.Items.Add("Daño");
            cmbMotivoMovimiento.Items.Add("Error de inventario");
            cmbMotivoMovimiento.Items.Add("Consumo interno");
        }


        private void frmEliminarStock_Load(object sender, EventArgs e)
        {
            CargarMotivos();
        }

        private void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            string motivo = cmbMotivoMovimiento.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(motivo))
            {
                MessageBox.Show("Debes seleccionar un motivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            ProductoNegocio productoNegocio = new ProductoNegocio();

            int stockAnterior = productoNegocio.ObtenerStockActual(idProducto);
           
            productoNegocio.EliminarStock(idProducto, cantidad);

           
           

            // ✅ Registrar el movimiento en la base de datos con la cantidad recibida
            MovimientoStock movimiento = new MovimientoStock
            {
                IdProducto = idProducto,
                IdTipoMovimiento = 5, // ✅ "Ajuste negativo"
                IdUsuario = idUsuario,
                CantidadMovida = cantidad,
                StockAnterior = stockAnterior,
                StockPosterior = stockAnterior - cantidad,
                MotivoMovimiento = motivo
            };

            MovimientoStockNegocio movimientoNegocio = new MovimientoStockNegocio();
            movimientoNegocio.RegistrarMovimientoStock(movimiento);

            MessageBox.Show("Stock eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            StockEliminado?.Invoke(this, EventArgs.Empty); // ✅ Notificar a `frmGestionarStock`
            this.Close(); // ✅ Cerrar `frmEliminarStock`
        }
    }
}
