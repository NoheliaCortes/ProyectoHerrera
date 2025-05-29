using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BNLayer;
using DataLayer;
using DataLayer.Modelos;

namespace ProyectoHerrera
{
    public partial class frmClientes : Form
    {

        private int idClienteSeleccionado;
        public frmClientes()
        {
            InitializeComponent();
        }

        private ClienteNegocio clienteNegocio = new ClienteNegocio();

        private void CargarClientes()
        {
            List<Cliente> lista = clienteNegocio.ObtenerClientes();
            dgvClientes.DataSource = lista;
        }

        public void RedondearPanel(Panel panel, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            path.AddArc(new Rectangle(panel.Width - radio, 0, radio, radio), 270, 90);
            path.AddArc(new Rectangle(panel.Width - radio, panel.Height - radio, radio, radio), 0, 90);
            path.AddArc(new Rectangle(0, panel.Height - radio, radio, radio), 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
        }



        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
            cbEstado.Items.AddRange(new string[] { "Activo", "Inactivo" });
            cbEstado.SelectedIndex = 0;
            RedondearPanel(PanelClientes, 35);

        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text) || !txtTelefono.Text.All(char.IsDigit) || txtTelefono.Text.Length < 8)
            {
                MessageBox.Show("El teléfono debe contener solo números y al menos 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text) || txtDireccion.Text.Length < 5)
            {
                MessageBox.Show("La dirección debe tener al menos 5 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return false;
            }

            if (cbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un estado válido (Activo/Inactivo).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbEstado.Focus();
                return false;
            }

            return true;
        }



        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                try
                {
                    Cliente cliente = new Cliente
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = txtApellido.Text.Trim(),
                        Telefono = txtTelefono.Text.Trim(),
                        Direccion = txtDireccion.Text.Trim(),
                        Estado = cbEstado.SelectedItem.ToString() == "Activo"
                    };

                    bool exito = clienteNegocio.InsertarCliente(cliente);
                    if (exito)
                    {
                        MessageBox.Show("Cliente registrado con éxito.");
                        CargarClientes();
                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el cliente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado > 0 && ValidarFormulario())
            {
                try
                {
                    Cliente cliente = new Cliente
                    {
                        IdCliente = idClienteSeleccionado,
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = txtApellido.Text.Trim(),
                        Telefono = txtTelefono.Text.Trim(),
                        Direccion = txtDireccion.Text.Trim(),
                        Estado = cbEstado.SelectedItem.ToString() == "Activo"
                    };

                    bool exito = clienteNegocio.ActualizarCliente(cliente);
                    if (exito)
                    {
                        MessageBox.Show("Cliente actualizado con éxito.");
                        CargarClientes();
                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el cliente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un cliente antes de editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado > 0)
            {
                DialogResult result = MessageBox.Show("¿Estás segura de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool exito = clienteNegocio.EliminarCliente(idClienteSeleccionado);
                    if (exito)
                    {
                        MessageBox.Show("Cliente eliminado.");
                        CargarClientes();
                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un cliente antes de eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }




        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            cbEstado.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void ConfigurarDataGridView()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            dgvClientes.Columns.Clear();

            
            DataGridViewTextBoxColumn colIdCliente = new DataGridViewTextBoxColumn();
            colIdCliente.DataPropertyName = "IdCliente"; 
            colIdCliente.HeaderText = "ID Cliente";
            colIdCliente.Visible = false;
            dgvClientes.Columns.Add(colIdCliente);

            
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre";
            dgvClientes.Columns.Add(colNombre);
        }

       

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                Cliente clienteSeleccionado = (Cliente)dgvClientes.Rows[e.RowIndex].DataBoundItem; 
                idClienteSeleccionado = clienteSeleccionado.IdCliente;

                txtNombre.Text = clienteSeleccionado.Nombre;
                txtApellido.Text = clienteSeleccionado.Apellido;
                txtTelefono.Text = clienteSeleccionado.Telefono;
                txtDireccion.Text = clienteSeleccionado.Direccion;
                cbEstado.SelectedItem = clienteSeleccionado.Estado ? "Activo" : "Inactivo";





            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
