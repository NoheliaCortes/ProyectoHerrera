using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BNLayer
{
    public class ClienteNegocio
    {
        private ClienteDatos clienteDatos = new ClienteDatos();

        public bool InsertarCliente(Cliente cliente)
        {
            try
            {
                return clienteDatos.InsertarCliente(cliente);
            }
            catch (Exception ex)
            {
                // Podés loggear el error aquí si querés
                throw new Exception("Error en la capa de negocio insertando cliente: " + ex.Message);
            }
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            try
            {
                return clienteDatos.ActualizarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio actualizando cliente: " + ex.Message);
            }
        }

        public bool EliminarCliente(int idCliente)
        {
            try
            {
                return clienteDatos.EliminarCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio eliminando cliente: " + ex.Message);
            }
        }

        public bool CambiarEstadoCliente(int idCliente, string nuevoEstado)
        {
            try
            {
                return clienteDatos.CambiarEstadoCliente(idCliente, nuevoEstado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio cambiando estado cliente: " + ex.Message);
            }
        }

        public List<Cliente> ObtenerClientes()
        {
            return clienteDatos.ObtenerClientes(); 
        }
    }

}
