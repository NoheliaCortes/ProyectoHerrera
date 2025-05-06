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
    public partial class frmInventario : Form
    {
        public frmInventario()
        {
            InitializeComponent();
        }

        

        private void frmInventario_Load(object sender, EventArgs e)
        {
            
            CargarProductosConStock();
        }
        public void CargarProductosConStock()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            dgvInventario.DataSource = productoNegocio.ObtenerProductosConStock();

            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

         

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            frmRegistrarProducto frmRegistro = new frmRegistrarProducto();
            frmRegistro.ShowDialog(); 
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow != null) // Alternativa más precisa para verificar la selección
            {
                int idProducto = Convert.ToInt32(dgvInventario.CurrentRow.Cells["IdProducto"].Value);

                string nombreProducto = dgvInventario.CurrentRow.Cells["NombreProducto"].Value.ToString();

               

                frmGestionarStock frmGestionarStock = new frmGestionarStock(idProducto, nombreProducto);

                frmGestionarStock.StockActualizado += (s, args) =>
                {
                    CargarProductosConStock(); // Recarga los datos
                };

              


                frmGestionarStock.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto antes de gestionar su stock.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow != null) // Verifica si hay un producto seleccionado
            {
                int idProducto = Convert.ToInt32(dgvInventario.CurrentRow.Cells["IdProducto"].Value);

                // Abre el formulario de actualización y le pasa el ID del producto
                frmActualizarProducto frmActualizar = new frmActualizarProducto(idProducto);
                frmActualizar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow != null)
            {
                int idProducto = Convert.ToInt32(dgvInventario.CurrentRow.Cells["id_producto"].Value);

                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                                         "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    ProductoNegocio productoNegocio = new ProductoNegocio();
                    productoNegocio.EliminarProducto(idProducto);

                    MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarProductosConStock(); // Recargar el `DataGridView`
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
