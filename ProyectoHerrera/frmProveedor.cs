using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DataLayer.Modelos;
using BNLayer;

namespace ProyectoHerrera
{
    public partial class frmProveedor : Form
    {
        private ProveedorNegocio proveedorNegocio;
        private BindingList<Proveedor> listaBinding;
        private BindingSource bs;
        private int? seleccionadoId;
        private bool enEdicion, esNuevo;

        public frmProveedor()
        {
            InitializeComponent();

           
            bs = new BindingSource();
            this.Load += FrmProveedor_Load;
            dgvProveedor.SelectionChanged += DgvProveedor_SelectionChanged;
           

            // Configuración del DataGridView
            dgvProveedor.AutoGenerateColumns = true;
            dgvProveedor.MultiSelect = false;
            dgvProveedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedor.AllowUserToAddRows = false;
            dgvProveedor.AllowUserToDeleteRows = false;
            dgvProveedor.ReadOnly = true;
            dgvProveedor.DataSource = bs;
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            proveedorNegocio = new ProveedorNegocio();
            ConfigurarColumnas();
            CargarProveedores();
            ConfiguracionInicio();
        }

        private void ConfigurarColumnas()
        {
            if (dgvProveedor.Columns.Count > 0) return;

            dgvProveedor.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "Id_Proveedor",
                Visible = true,
            });
            dgvProveedor.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Nombre",
                DataPropertyName = "nombre"
            });
            dgvProveedor.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTelefono",
                HeaderText = "Teléfono",
                DataPropertyName = "telefono"
            });
        }

        private void CargarProveedores()
        {
            var lista = proveedorNegocio.ObtenerProveedores();
            listaBinding = new BindingList<Proveedor>(lista);
            bs.DataSource = listaBinding;
            dgvProveedor.ClearSelection();
        }

        private void ConfiguracionInicio()
        {
            LimpiarFormulario();
            seleccionadoId = null;
            enEdicion = esNuevo = false;
            SetControles(edicion: false);
        }

        private void DgvProveedor_SelectionChanged(object sender, EventArgs e)
        {
            if (esNuevo && dgvProveedor.SelectedRows.Count == 0) return;

            if (dgvProveedor.SelectedRows.Count != 1)
            {
                ConfiguracionInicio();
                return;
            }

            var p = dgvProveedor.SelectedRows[0].DataBoundItem as Proveedor;
            if (p == null) return;

            seleccionadoId = p.Id_Proveedor;
            txtNombre.Text = p.nombre;
            txtTelefono.Text = p.telefono;

            enEdicion = true;
            esNuevo = false;
            SetControles(true);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            enEdicion = esNuevo = true;
            seleccionadoId = null;
            SetControles(edicion: true);
            txtNombre.Focus();
            btnAgregar.Enabled = true;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            var nuevo = new Proveedor(
                id_Proveedor: 0,
                nombre: txtNombre.Text.Trim(),
                telefono: txtTelefono.Text.Trim()
            );

            int idGenerado = proveedorNegocio.AgregarProveedor(nuevo);
            MessageBox.Show($"Proveedor agregado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarProveedores();
            SeleccionarEnGrid(idGenerado);
            ConfiguracionInicio();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (!enEdicion || esNuevo || !seleccionadoId.HasValue) return;
            if (!ValidarFormulario()) return;

            var actualizado = new Proveedor(
                id_Proveedor: seleccionadoId.Value,
                nombre: txtNombre.Text.Trim(),
                telefono: txtTelefono.Text.Trim()
            );

            proveedorNegocio.ActualizarProveedor(actualizado);
            MessageBox.Show("Proveedor actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarProveedores();
            ConfiguracionInicio();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!seleccionadoId.HasValue) return;
            if (MessageBox.Show("¿Confirma eliminar este proveedor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            proveedorNegocio.EliminarProveedor(seleccionadoId.Value);
            MessageBox.Show("Proveedor eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarProveedores();
            ConfiguracionInicio();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            CargarProveedores();
            ConfiguracionInicio();
        }

        private void SeleccionarEnGrid(int id)
        {
            foreach (DataGridViewRow row in dgvProveedor.Rows)
            {
                if ((row.DataBoundItem as Proveedor)?.Id_Proveedor == id)
                {
                    row.Selected = true;
                    dgvProveedor.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text) || !txtTelefono.Text.All(char.IsDigit))
            {
                MessageBox.Show("El teléfono debe contener solo dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }
            if (txtTelefono.Text.Length < 8)
            {
                MessageBox.Show("El telefono debe tener al menos 8 digitos.","Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }

        private void dgvProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SetControles(bool edicion)
        {
            txtNombre.Enabled = edicion;
            txtTelefono.Enabled = edicion;
            btnAgregar.Enabled = !edicion;
            btnActualizar.Enabled = edicion && !esNuevo;
            btnEliminar.Enabled = edicion && !esNuevo;
            btnNuevo.Enabled = !edicion;
            btnCancelar.Enabled = edicion;
        }
    }

}