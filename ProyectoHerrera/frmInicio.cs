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
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


        }

       

        private void btnVentas_Click(object sender, EventArgs e)
        {
            frmVenta nuevoFormulario = new frmVenta(); 
            nuevoFormulario.Show(); 
            this.Hide(); 
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmInventario nuevoFormulario = new frmInventario();
            nuevoFormulario.Show();
            this.Hide();

        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnInsumos_Click(object sender, EventArgs e)
        {

        }
    }
}
