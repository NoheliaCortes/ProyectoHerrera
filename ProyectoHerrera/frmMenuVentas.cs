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
    public partial class frmMenuVentas : Form
    {
        public frmMenuVentas()
        {
            InitializeComponent();
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            frmVenta nuevoformulario = new frmVenta();
            nuevoformulario.ShowDialog();   
        }

        private void btnHistorialVentas_Click(object sender, EventArgs e)
        {
            frmHistorialVentas nuevoformulario = new frmHistorialVentas();
            nuevoformulario.ShowDialog();
        }
    }
}
