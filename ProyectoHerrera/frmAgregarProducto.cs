using BNLayer;
using DataLayer;
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


          





        }


       



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecioProducto.Text) ||
                    string.IsNullOrWhiteSpace(txtCantidadMinima.Text) ||
                    string.IsNullOrWhiteSpace(txtCostoProduccion.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ProductoNegocio productoNegocio = new ProductoNegocio();

                int idSabor = Convert.ToInt32(cmbSabor.SelectedValue);
                int idPeso = Convert.ToInt32(cmbPeso.SelectedValue);

              
                if (productoNegocio.ExisteProducto(idSabor, idPeso))
                {
                    MessageBox.Show("Ya existe un producto con este sabor y peso.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


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

               
                
                productoNegocio.RegistrarProducto(nuevoProducto);

                MessageBox.Show("Producto registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ((frmInventario)Application.OpenForms["frmInventario"]).CargarProductosConStock();
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al registrar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLinea.SelectedItem != null)
            {
                int idLinea = ((Linea)cmbLinea.SelectedItem).IdLinea;


                cmbSabor.Enabled = true;

                SaborNegocio saborNegocio = new SaborNegocio();
                cmbSabor.DataSource = saborNegocio.ObtenerSaboresPorLinea(idLinea);
                cmbSabor.DisplayMember = "nombre_sabor";
                cmbSabor.ValueMember = "id_sabor";
            }
            else
            {
                cmbSabor.Enabled = false;
                cmbSabor.DataSource = null;
            }
        }

        private void GenerarNombreProducto()
        {
            if (cmbSabor.SelectedItem != null && cmbPeso.SelectedItem != null && cmbMedida.SelectedItem != null)
            {
                string sabor = cmbSabor.SelectedItem is Sabor ? ((Sabor)cmbSabor.SelectedItem).NombreSabor : cmbSabor.Text; // ✅ Convertir correctamente
                string peso = ((Peso)cmbPeso.SelectedItem).NombrePeso;
                string unidadMedida = ((Medida)cmbMedida.SelectedItem).NombreMedida;

                txtNombreProducto.Text = $"Sorbete {sabor} {peso} {unidadMedida}";
            }
            else
            {
                txtNombreProducto.Text = ""; 
            }
        }

        private void cmbSabor_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            GenerarNombreProducto();
        }

        private void cmbMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerarNombreProducto();
        }

        private void cmbPeso_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerarNombreProducto();
        }
    }
}
