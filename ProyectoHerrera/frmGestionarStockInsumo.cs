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
    public partial class frmGestionarStockInsumo : Form
    {
        private int idInsumo;
        public event Action StockActualizado;

        public frmGestionarStockInsumo(int idInsumo, string nombreInsumo, int stockActual)
        {
            InitializeComponent();
            this.idInsumo = idInsumo; // ✅ Guardamos el ID del insumo para futuras modificaciones

            txtInsumo.Text = nombreInsumo;
            txtStockActual.Text = stockActual.ToString();
            txtInsumo.Tag = idInsumo; 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInsumo.Tag?.ToString(), out int idInsumo) || idInsumo <= 0)
            {
                MessageBox.Show("Error: No se ha seleccionado un insumo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidadAgregar) || cantidadAgregar <= 0)
            {
                MessageBox.Show("Error: Ingresa una cantidad válida mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int stockActual = Convert.ToInt32(txtStockActual.Text);
            int stockNuevo = stockActual + cantidadAgregar;

            InsumoNegocio insumoNegocio = new InsumoNegocio();
            if (insumoNegocio.ActualizarStock(idInsumo, stockNuevo))
            {
                txtStockNuevo.Text = stockNuevo.ToString();
                MessageBox.Show("¡Stock actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StockActualizado?.Invoke(); // ✅ Disparar evento para actualizar `dgvInsumos`
            }
            else
            {
                MessageBox.Show("Error al actualizar el stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInsumo.Tag?.ToString(), out int idInsumo) || idInsumo <= 0)
            {
                MessageBox.Show("Error: No se ha seleccionado un insumo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidadEliminar) || cantidadEliminar <= 0)
            {
                MessageBox.Show("Error: Ingresa una cantidad válida mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int stockActual = Convert.ToInt32(txtStockActual.Text);
            if (cantidadEliminar > stockActual)
            {
                MessageBox.Show("No puedes eliminar más stock del disponible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int stockNuevo = stockActual - cantidadEliminar;

            InsumoNegocio insumoNegocio = new InsumoNegocio();
            if (insumoNegocio.ActualizarStock(idInsumo, stockNuevo))
            {
                txtStockNuevo.Text = stockNuevo.ToString();
                MessageBox.Show("¡Stock actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StockActualizado?.Invoke(); // ✅ Disparar evento para actualizar `dgvInsumos`
            }
            else
            {
                MessageBox.Show("Error al actualizar el stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            StockActualizado?.Invoke(); // ✅ Asegurar que `dgvInsumos` se actualice en `frmInsumos`
            this.Close();
        }

    }
}
