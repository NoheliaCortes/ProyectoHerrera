using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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


        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
            cbEstado.Items.AddRange(new string[] { "Activo", "Inactivo" });
            cbEstado.SelectedIndex = 0;

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.CurrentRow == null)
                {
                    MessageBox.Show("Seleccioná un cliente para editar.");
                    return;
                }

                int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["id_cliente"].Value);

                Cliente cliente = new Cliente
                {
                    IdCliente = id,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.CurrentRow == null)
                {
                    MessageBox.Show("Seleccioná un cliente para eliminar.");
                    return;
                }

                int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["id_cliente"].Value);

                DialogResult result = MessageBox.Show("¿Estás segura de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool exito = clienteNegocio.EliminarCliente(id);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

       

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                txtNombre.Text = fila.Cells["nombre"].Value?.ToString() ?? "";
                txtApellido.Text = fila.Cells["apellido"].Value?.ToString() ?? "";
                txtTelefono.Text = fila.Cells["telefono"].Value?.ToString() ?? "";
                txtDireccion.Text = fila.Cells["direccion"].Value?.ToString() ?? "";

                bool estado = false;
                if (fila.Cells["estado"].Value != null)
                    estado = Convert.ToBoolean(fila.Cells["estado"].Value);

                cbEstado.SelectedItem = estado ? "Activo" : "Inactivo";
            }
        }
    }
}
