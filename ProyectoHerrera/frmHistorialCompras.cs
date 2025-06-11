using BNLayer;
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
    public partial class frmHistorialCompras : Form
    {
        private CompraNegocio compraNegocio = new CompraNegocio();
        public frmHistorialCompras()
        {
            InitializeComponent();
        }

        private void frmHistorialCompras_Load(object sender, EventArgs e)
        {
            CargarHistorialCompras();
        }

        private void CargarHistorialCompras()
        {
            dgvCompras.DataSource = compraNegocio.ObtenerHistorialCompras();
        }

    }
}
