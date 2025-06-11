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
using System.Drawing.Drawing2D;
using static ProyectoHerrera.Program;
using DataLayer;

namespace ProyectoHerrera
{
    public partial class frmVenta : Form
    {

        public Usuario UsuarioLogueado { get; set; }

        



        public frmVenta()
        {
            InitializeComponent();
            this.Load += frmVenta_Load;




        }


        public void RedondearPanel(Panel panel, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            path.AddArc(new Rectangle(panel.Width - radio, 0, radio, radio), 270, 90);
            path.AddArc(new Rectangle(panel.Width - radio, panel.Height - radio, radio, radio), 0, 90);
            path.AddArc(new Rectangle(0, panel.Height - radio, radio, radio), 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
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
            

            UsuarioLogueado = SesionUsuario.UsuarioActual;

            if (UsuarioLogueado != null)
            {
                txtUsuario.Text = $"{UsuarioLogueado.NombreUsuario} {UsuarioLogueado.ApellidoUsuario}";
                txtUsuario.ReadOnly = true; // ✅ Evitar que el usuario cambie manualmente
            }


            cmbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;

            RedondearPanel(PanelVentas, 35);
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

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
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

                int idProducto = Convert.ToInt32(row["id_producto"]);
                string nombreProducto = row["nombre_producto"].ToString();
                decimal precio = Convert.ToDecimal(row["precio_producto"]);
                decimal descuentoUnitario = Convert.ToDecimal(row["descuento_producto"]);
                int cantidadMinimaDescuento = Convert.ToInt32(row["cantidad_minima_descuento"]);

                
                if (!productoNegocio.VerificarStock(idProducto, cantidad))
                {
                    MessageBox.Show($"No hay suficiente stock para {nombreProducto}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }


                int idCliente = (cmbCliente.SelectedItem != null) ? ((Cliente)cmbCliente.SelectedItem).IdCliente : 1;

                // Aplicar descuento según el tipo de cliente
                bool aplicarDescuento = (idCliente != 1) || (cantidad >= cantidadMinimaDescuento); // Si es cliente registrado, siempre aplica. Si es genérico, debe comprar 25+ unidades.
                decimal descuento = aplicarDescuento ? cantidad * descuentoUnitario : 0m;
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

        private void btnRegistrarVentas_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en la venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtTotal.Text, out decimal total))
            {
                MessageBox.Show("Total inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Si no hay cliente seleccionado, usar el "Cliente Genérico"
            int idCliente = (cmbCliente.SelectedItem != null) ? ((Cliente)cmbCliente.SelectedItem).IdCliente : 1;

            List<DetalleVenta> detallesVenta = new List<DetalleVenta>();
            VentaNegocio ventaNegocio = new VentaNegocio();
            int idUsuario = SesionUsuario.UsuarioActual?.IdUsuario ?? 0;

            ProductoNegocio productoNegocio = new ProductoNegocio();

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.Cells["Producto"].Value != null)
                {
                    int idProducto = ventaNegocio.ObtenerIdProducto(row.Cells["Producto"].Value.ToString()); // ✅ Se define aquí
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value); // ✅ Se define aquí
                    int stockAnterior = productoNegocio.ObtenerStockActual(idProducto);


                    detallesVenta.Add(new DetalleVenta
                    {
                        IdProducto = ventaNegocio.ObtenerIdProducto(row.Cells["Producto"].Value.ToString()),
                        NombreProducto = row.Cells["Producto"].Value.ToString(),
                        Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                        Subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value)
                    });

                    MovimientoStock movimiento = new MovimientoStock
                    {


                        IdProducto = idProducto,
                        IdTipoMovimiento = 2, // ✅ "Venta"
                        IdUsuario = idUsuario,
                        CantidadMovida = cantidad,
                        StockAnterior = stockAnterior,
                        StockPosterior = stockAnterior - cantidad,
                        MotivoMovimiento = null // ✅ Las ventas no requieren motivo
                    };


                    MovimientoStockNegocio movimientoNegocio = new MovimientoStockNegocio();
                    movimientoNegocio.RegistrarMovimientoStock(movimiento);



                }
            }

          
        


            ventaNegocio.ProcesarVenta(idCliente, idUsuario, total, detallesVenta); // ✅ Usar cliente genérico si es necesario

            MessageBox.Show("Venta registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvProductos.Rows.Clear();
            txtTotal.Text = "0.00";
            txtPago.Text = "";
            txtCambio.Text = "0.00";
        }

        private void txtCambio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
