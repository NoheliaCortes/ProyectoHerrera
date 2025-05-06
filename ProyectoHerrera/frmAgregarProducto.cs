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
using DataLayer;
using BNLayer;

namespace ProyectoHerrera
{
    public partial class frmRegistrarProducto : Form
    {
        public frmRegistrarProducto()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmRegistrarProducto_Load(object sender, EventArgs e)
        {
            LineaNegocio lineaNegocio = new LineaNegocio();

            // Configurar el ComboBox para mostrar los nombres de las líneas
            cmbLinea.DataSource = lineaNegocio.ObtenerLineas(); // Asigna la lista de líneas al ComboBox
            cmbLinea.DisplayMember = "NombreLinea"; // Campo a mostrar en el ComboBox
            cmbLinea.ValueMember = "IdLinea"; // Campo subyacente (id_linea)


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






        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar los campos del formulario
                if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecioProducto.Text) ||
                    string.IsNullOrWhiteSpace(txtCantidadMinima.Text) ||
                    string.IsNullOrWhiteSpace(txtCostoProduccion.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear un objeto Producto con los datos ingresados
                Producto nuevoProducto = new Producto
                {
                    NombreProducto = txtNombreProducto.Text,
                    PrecioProducto = Convert.ToDecimal(txtPrecioProducto.Text),
                    CostoProduccion = Convert.ToDecimal(txtCostoProduccion.Text),
                    CantidadMinimaDescuento = Convert.ToInt32(txtCantidadMinima.Text),
                    DescuentoProducto = Convert.ToInt32(txtDescuentoProducto.Text),
                    IdLinea = Convert.ToInt32(cmbLinea.SelectedValue),
                    IdSabor = Convert.ToInt32(cmbSabor.SelectedValue),
                    IdPeso = Convert.ToInt32(cmbPeso.SelectedValue),
                    IdMedida = Convert.ToInt32(cmbMedida.SelectedValue),
                    IdEnvase = Convert.ToInt32(cmbEnvase.SelectedValue)
                   
                };

                // Guardar el producto usando la capa de negocio
                ProductoNegocio productoNegocio = new ProductoNegocio();
                productoNegocio.RegistrarProducto(nuevoProducto);

                MessageBox.Show("Producto registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ((frmInventario)Application.OpenForms["frmInventario"]).CargarProductosConStock();
                this.Close(); // Cierra el formulario de registro
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al registrar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
