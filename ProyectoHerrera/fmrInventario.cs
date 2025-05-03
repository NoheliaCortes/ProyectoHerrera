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
        private void CargarProductosConStock()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            dgvInventario.DataSource = productoNegocio.ObtenerProductosConStock();

            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

         

        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRegistrarProducto frmRegistro = new frmRegistrarProducto();
            frmRegistro.ShowDialog(); 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
