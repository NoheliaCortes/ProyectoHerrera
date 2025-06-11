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
    public partial class frmMenuReportes : Form
    {
        public frmMenuReportes()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmMovimientosStock frm = new frmMovimientosStock();
            frm.ShowDialog();
        }
    }
}
