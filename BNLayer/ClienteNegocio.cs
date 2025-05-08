using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataLayer.VentaDatos;

namespace BNLayer
{
    
    public class ClienteNegocio
    {
        private ClienteDatos clienteDatos = new ClienteDatos();

        public void AgregarCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre) || string.IsNullOrWhiteSpace(cliente.Apellido))
            {
                throw new Exception("El nombre y apellido no pueden estar vacíos.");
            }

            if (cliente.Telefono.Length != 10 || !long.TryParse(cliente.Telefono, out _))
            {
                throw new Exception("El teléfono debe tener exactamente 10 dígitos.");
            }

            clienteDatos.AgregarCliente(cliente);
        }

        public List<Cliente> ObtenerClientes()
        {
            return clienteDatos.ObtenerClientes();
        }

        public void EditarCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre) || string.IsNullOrWhiteSpace(cliente.Apellido))
            {
                throw new Exception("El nombre y apellido no pueden estar vacíos.");
            }

            clienteDatos.EditarCliente(cliente);
        }

        public void EliminarCliente(int idCliente)
        {
            clienteDatos.EliminarCliente(idCliente);
        }
    }
}
