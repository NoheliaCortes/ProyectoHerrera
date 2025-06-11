using BNLayer;
using DataLayer.Modelos;
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


            ClienteNegocio clienteNegocio = new ClienteNegocio();
            List<Cliente> clientes = clienteNegocio.ObtenerClientes();

            cmbCliente.DataSource = clientes;
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "IdCliente";
            cmbCliente.SelectedIndex = -1;
             

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Usuario> usuarios = usuarioNegocio.ObtenerUsuarios();
            cmbUsuario.DataSource = usuarios;
            cmbUsuario.DisplayMember = "NombreUsuario";
            cmbUsuario.ValueMember = "IdUsuario";
            cmbUsuario.SelectedIndex = -1;

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime? fechaInicio = dtpFechaInicio.Value.Date;
            DateTime? fechaFin = dtpFechaFin.Value.Date;

            // ✅ Obtener ID de cliente y usuario desde los `ComboBox`
            int? idCliente = (cmbCliente.SelectedItem != null) ? ((Cliente)cmbCliente.SelectedItem).IdCliente : (int?)null;
            int? idUsuario = (cmbUsuario.SelectedItem != null) ? ((Usuario)cmbUsuario.SelectedItem).IdUsuario : (int?)null;

            VentaNegocio ventaNegocio = new VentaNegocio();
            dgvHistorialVentas.DataSource = ventaNegocio.ObtenerVentasPorFiltro(fechaInicio, fechaFin, idCliente, idUsuario);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;
            cmbCliente.SelectedIndex = -1; // ✅ Deseleccionar cliente
            cmbUsuario.SelectedIndex = -1; // ✅ Deseleccionar usuario

            // ✅ Mostrar todas las ventas sin filtros
            VentaNegocio ventaNegocio = new VentaNegocio();
            dgvHistorialVentas.DataSource = ventaNegocio.ObtenerHistorialVentas();

        }
    }
}
