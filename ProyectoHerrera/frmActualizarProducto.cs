using BNLayer;
using DataLayer;
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
   
    
        public partial class frmActualizarProducto : Form
        {
            private int idProducto;

            public frmActualizarProducto(int idProducto)
            {
                InitializeComponent();
                this.idProducto = idProducto;
            frmActualizarProducto_Load(null, null);
            CargarDatosProducto();
            }

        // Método para obtener los datos del producto y mostrarlos en los controles
        private void CargarDatosProducto()
        {
            try
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                Producto producto = productoNegocio.ObtenerProductoPorId(idProducto);

                if (producto != null)
                {
                    txtNombreProducto.Text = producto.NombreProducto;
                    txtPrecioProducto.Text = producto.PrecioProducto.ToString();
                    txtCostoProduccion.Text = producto.CostoProduccion.ToString();
                    txtDescuentoProducto.Text = producto.DescuentoProducto.ToString();
                    txtCantidadMinimaDescuento.Text = producto.CantidadMinimaDescuento.ToString();

                    // Seleccionar los valores correctos en los ComboBox
                    cmbLinea.SelectedValue = producto.IdLinea;
                    cmbSabor.SelectedValue = producto.IdSabor;
                    cmbMedida.SelectedValue = producto.IdMedida;
                    cmbPeso.SelectedValue = producto.IdPeso;
                    cmbEnvase.SelectedValue = producto.IdEnvase;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo cargar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            try
            {
                Producto producto = new Producto
                {
                    IdProducto = idProducto,
                    NombreProducto = txtNombreProducto.Text,
                    PrecioProducto = Convert.ToDecimal(txtPrecioProducto.Text),
                    CostoProduccion = Convert.ToDecimal(txtCostoProduccion.Text),
                    DescuentoProducto = Convert.ToDecimal(txtDescuentoProducto.Text),
                    CantidadMinimaDescuento = Convert.ToInt32(txtCantidadMinimaDescuento.Text),
                    IdLinea = Convert.ToInt32(cmbLinea.SelectedValue),
                    IdSabor = Convert.ToInt32(cmbSabor.SelectedValue),
                    IdPeso = Convert.ToInt32(cmbPeso.SelectedValue),
                    IdMedida = Convert.ToInt32(cmbMedida.SelectedValue),
                    IdEnvase = Convert.ToInt32(cmbEnvase.SelectedValue)
                };

                ProductoNegocio productoNegocio = new ProductoNegocio();
                productoNegocio.ActualizarProducto(producto);

                MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar `dgvInventario` en `frmInventario`
                ((frmInventario)Application.OpenForms["frmInventario"]).CargarProductosConStock();

                this.Close(); // Cierra el formulario después de actualizar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmActualizarProducto_Load(object sender, EventArgs e)
        {
          
            LineaNegocio lineaNegocio = new LineaNegocio();
            cmbLinea.DataSource = lineaNegocio.ObtenerLineas();
            cmbLinea.DisplayMember = "NombreLinea";
            cmbLinea.ValueMember = "IdLinea";

            SaborNegocio saborNegocio = new SaborNegocio();
            cmbSabor.DataSource = saborNegocio.ObtenerSabores();
            cmbSabor.DisplayMember = "NombreSabor";
            cmbSabor.ValueMember = "IdSabor";

            MedidaNegocio medidaNegocio = new MedidaNegocio();
            cmbMedida.DataSource = medidaNegocio.ObtenerMedidas();
            cmbMedida.DisplayMember = "NombreMedida";
            cmbMedida.ValueMember = "IdMedida";

            PesoNegocio pesoNegocio = new PesoNegocio();
            cmbPeso.DataSource = pesoNegocio.ObtenerPesos();
            cmbPeso.DisplayMember = "NombrePeso";
            cmbPeso.ValueMember = "IdPeso";

            EnvaseNegocio envaseNegocio = new EnvaseNegocio();
            cmbEnvase.DataSource = envaseNegocio.ObtenerEnvases();
            cmbEnvase.DisplayMember = "TipoEnvase";
            cmbEnvase.ValueMember = "IdEnvase";

            // Llamar al método para cargar los datos del producto
            CargarDatosProducto();
        

    }
}
    
}
