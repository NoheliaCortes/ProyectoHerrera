using BNLayer;
using Guna.UI2.WinForms;
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
    public partial class frmHistorialVentas : Form
    {
        public frmHistorialVentas()
        {
            InitializeComponent();
        }

        private void frmHistorialVentas_Load(object sender, EventArgs e)
        {
            VentaNegocio ventaNegocio = new VentaNegocio();
            dgvHistorialVentas.DataSource = ventaNegocio.ObtenerHistorialVentas();


            if (dgvHistorialVentas.Columns["btnVerDetalles"] == null)
            {
                DataGridViewImageColumn imgDetalles = new DataGridViewImageColumn();
                imgDetalles.Name = "btnVerDetalles";
                imgDetalles.HeaderText = "Detalles";
                imgDetalles.Image = Properties.Resources.Detalles; // ✅ Usa una imagen de tu proyecto
                imgDetalles.ImageLayout = DataGridViewImageCellLayout.Zoom; // ✅ Ajustar imagen al tamaño de celda

                dgvHistorialVentas.Columns.Add(imgDetalles);
            }

        }

        private void dgvHistorialVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (dgvHistorialVentas.Columns.Contains("btnVerDetalles") && e.ColumnIndex == dgvHistorialVentas.Columns["btnVerDetalles"].Index && e.RowIndex >= 0)
            {
                
                int idVenta = Convert.ToInt32(dgvHistorialVentas.Rows[e.RowIndex].Cells["idVenta"].Value);

              
                frmDetalleVenta detalleVenta = new frmDetalleVenta(idVenta);
                detalleVenta.ShowDialog();
            }
        }


        private void dgvHistorialVentas_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvHistorialVentas.Columns.Contains("btnVerDetalles") && e.ColumnIndex == dgvHistorialVentas.Columns["btnVerDetalles"].Index && e.RowIndex >= 0)
            {
                dgvHistorialVentas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGray; 
            }
        }

        private void dgvHistorialVentas_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // ✅ Verificar si la columna "btnVerDetalles" existe antes de acceder a ella
            if (dgvHistorialVentas.Columns.Contains("btnVerDetalles") && e.ColumnIndex == dgvHistorialVentas.Columns["btnVerDetalles"].Index && e.RowIndex >= 0)
            {
                dgvHistorialVentas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White; // ✅ Regresa a blanco
            }
        }




    }
}
