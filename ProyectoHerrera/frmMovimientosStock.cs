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
    public partial class frmMovimientosStock : Form
    {
        

        public frmMovimientosStock()
        {
            InitializeComponent();
        }

        private void frmMovimientosStock_Load(object sender, EventArgs e)
        {
            CargarMovimientosStock();
            
        }
        private MovimientoStockNegocio movimientoNegocio = new MovimientoStockNegocio();

       

      
        private void CargarMovimientosStock()
        {
            dgvMovimientosStock.DataSource = movimientoNegocio.ObtenerMovimientosStock();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
