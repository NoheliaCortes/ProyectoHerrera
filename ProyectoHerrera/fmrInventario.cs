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
using DataLayer.Modelos;
using System.Drawing.Drawing2D;


namespace ProyectoHerrera
{
    public partial class frmInventario : Form
    {

        private int idLineaSeleccionada;
        private string nombreLineaSeleccionada;


        public frmInventario()
        {
            InitializeComponent();
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


        private void frmInventario_Load(object sender, EventArgs e)
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


            cmbLinea.SelectedIndex = -1;
            cmbSabor.SelectedIndex = -1;
            cmbPeso.SelectedIndex = -1;
            cmbMedida.SelectedIndex = -1;



            CargarProductosConStock();
            CargarLineas();

            RedondearPanel(PanelInventario, 35);
            RedondearPanel(PanelSabores, 35);

        }

       


       
        public void CargarProductosConStock()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            dgvInventario.DataSource = productoNegocio.ObtenerProductosConStock();

            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmRegistrarProducto frmRegistro = new frmRegistrarProducto();
            frmRegistro.ShowDialog();
        }





        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow != null)
            {
                int idProducto = Convert.ToInt32(dgvInventario.CurrentRow.Cells["IdProducto"].Value);


                frmActualizarProducto frmActualizar = new frmActualizarProducto(idProducto);
                frmActualizar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    

        private void CargarLineas()
        {
            LineaNegocio lineaNegocio = new LineaNegocio();
            dgvLineas.DataSource = lineaNegocio.ObtenerLineas(); 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarLinea frm = new frmAgregarLinea();
            frm.LineaAgregada += (s, args) => CargarLineas(); 
            frm.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idLineaSeleccionada > 0) 
            {
                DialogResult confirmacion = MessageBox.Show($"¿Eliminar la línea '{nombreLineaSeleccionada}'?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    LineaNegocio lineaNegocio = new LineaNegocio();

                    if (lineaNegocio.EliminarLinea(idLineaSeleccionada))
                    {
                        MessageBox.Show("Línea eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarLineas();
                        idLineaSeleccionada = 0; 
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar esta línea porque tiene productos registrados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una línea antes de eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



       
        private void dgvLineas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                idLineaSeleccionada = Convert.ToInt32(dgvLineas.Rows[e.RowIndex].Cells["IdLinea"].Value);
                nombreLineaSeleccionada = dgvLineas.Rows[e.RowIndex].Cells["NombreLinea"].Value.ToString();
            }
        }

        private void btnGestionarSabores_Click(object sender, EventArgs e)
        {
            if (idLineaSeleccionada > 0) 
            {
                frmGestionarSabores frm = new frmGestionarSabores(idLineaSeleccionada, nombreLineaSeleccionada);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecciona una línea antes de administrar sabores.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

        private void btnEliminarProducto_Click_1(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow != null)
            {
                int idProducto = Convert.ToInt32(dgvInventario.CurrentRow.Cells["IdProducto"].Value);

                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                                         "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    ProductoNegocio productoNegocio = new ProductoNegocio();
                    productoNegocio.EliminarProducto(idProducto);

                    MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarProductosConStock();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnStock_Click_1(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow != null)
            {
                int idProducto = Convert.ToInt32(dgvInventario.CurrentRow.Cells["IdProducto"].Value);

                string nombreProducto = dgvInventario.CurrentRow.Cells["NombreProducto"].Value.ToString();



                frmGestionarStock frmGestionarStock = new frmGestionarStock(idProducto, nombreProducto);

                frmGestionarStock.StockActualizado += (s, args) =>
                {
                    CargarProductosConStock();
                };




                frmGestionarStock.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto antes de gestionar su stock.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void FiltrarProductos()
        {
            int idLinea = cmbLinea.SelectedIndex != -1 ? Convert.ToInt32(cmbLinea.SelectedValue) : 0;
            int idSabor = cmbSabor.SelectedIndex != -1 ? Convert.ToInt32(cmbSabor.SelectedValue) : 0;
            int idPeso = cmbPeso.SelectedIndex != -1 ? Convert.ToInt32(cmbPeso.SelectedValue) : 0;
            int idMedida = cmbMedida.SelectedIndex != -1 ? Convert.ToInt32(cmbMedida.SelectedValue) : 0;

            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<ProductoConStock> productosFiltrados = productoNegocio.FiltrarProductos(idLinea, idSabor, idPeso, idMedida);

            dgvInventario.DataSource = productosFiltrados;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cmbLinea.SelectedIndex = -1;
            cmbSabor.SelectedIndex = -1;
            cmbPeso.SelectedIndex = -1;
            cmbMedida.SelectedIndex = -1;

            CargarProductosConStock();
        }

        private void cmbSabor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSabor_Click(object sender, EventArgs e)
        {
            if (cmbLinea.SelectedItem != null) 
            {
                int idLinea = ((Linea)cmbLinea.SelectedItem).IdLinea;

                SaborNegocio saborNegocio = new SaborNegocio();
                cmbSabor.DataSource = saborNegocio.ObtenerSaboresPorLinea(idLinea);
                cmbSabor.DisplayMember = "nombre_sabor";
                cmbSabor.ValueMember = "id_sabor";

                cmbSabor.DroppedDown = true; 
            }
        }
    }
}
