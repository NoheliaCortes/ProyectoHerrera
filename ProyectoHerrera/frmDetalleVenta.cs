using BNLayer;
using DataLayer;
using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProyectoHerrera
{
    public partial class frmDetalleVenta : Form
    {

        private int idVenta;

        public frmDetalleVenta(int idVenta)
        {
            InitializeComponent();
            this.idVenta = idVenta;
        }
        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            VentaNegocio ventaNegocio = new VentaNegocio();
            DataTable dtDetalles = ventaNegocio.ObtenerDetalleVenta(idVenta);

            // ✅ Agregar nueva columna para el descuento
            if (!dtDetalles.Columns.Contains("descuento_aplicado"))
            {
                dtDetalles.Columns.Add("descuento_aplicado", typeof(decimal));
            }

            // ✅ Calcular el descuento manualmente
            foreach (DataRow row in dtDetalles.Rows)
            {
                decimal precioUnitario = Convert.ToDecimal(row["precio_producto"]);
                int cantidad = Convert.ToInt32(row["cantidad"]);
                decimal subtotal = Convert.ToDecimal(row["subtotal"]);

                decimal precioTotal = cantidad * precioUnitario;
                decimal descuentoAplicado = precioTotal - subtotal; // ✅ Cálculo del descuento

                row["descuento_aplicado"] = descuentoAplicado;
            }

            dgvDetalleVenta.DataSource = dtDetalles;

            // ✅ Ajustar nombres de columnas para claridad
            dgvDetalleVenta.Columns["nombre_producto"].HeaderText = "Producto";
            dgvDetalleVenta.Columns["cantidad"].HeaderText = "Cantidad";
            dgvDetalleVenta.Columns["precio_producto"].HeaderText = "Precio Unitario";
            dgvDetalleVenta.Columns["descuento_aplicado"].HeaderText = "Descuento Aplicado";
            dgvDetalleVenta.Columns["subtotal"].HeaderText = "Subtotal";

            dgvDetalleVenta.Columns["descuento_aplicado"].DisplayIndex = 3;

            CargarDatosVenta();
        }

        private void CargarDatosVenta()
        {
            try
            {
                VentaNegocio ventaNegocio = new VentaNegocio();
                VentaInfo datosVenta = ventaNegocio.ObtenerVentaPorId(idVenta); // ✅ Obtener datos de la venta

                if (datosVenta != null)
                {
                    txtUsuario.Text = datosVenta.Usuario;
                    txtCliente.Text = datosVenta.Cliente;
                    txtFecha.Text = datosVenta.FechaVenta.ToString("dd/MM/yyyy");
                    txtTotal.Text = datosVenta.Total.ToString("C2", CultureInfo.CreateSpecificCulture("es-NI")); // ✅ Formato moneda
                }
                else
                {
                    MessageBox.Show("Error: No se encontraron datos de la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // ✅ Cierra el formulario si no hay datos
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
