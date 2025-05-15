using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ClienteDatos
    {
        private Conexion conexion = new Conexion();

        public List<Cliente> ObtenerClientes()
        {
            try
            {
                List<Cliente> lista = new List<Cliente>();

                using (SqlConnection con = conexion.ObtenerConexion())
                {
                    string query = "SELECT id_cliente, nombre, apellido, telefono, direccion, estado FROM Clientes";
                    SqlCommand cmd = new SqlCommand(query, con);
                  

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                IdCliente = Convert.ToInt32(reader["id_cliente"]),
                                Nombre = reader["nombre"].ToString(),
                                Apellido = reader["apellido"].ToString(),
                                Telefono = reader["telefono"].ToString(),
                                Direccion = reader["direccion"].ToString(),
                                Estado = Convert.ToBoolean(reader["estado"])
                            };

                            lista.Add(cliente);
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener clientes: " + ex.Message);
            }
        }








        public bool InsertarCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection con = conexion.ObtenerConexion())
                {
                    string query = "INSERT INTO Clientes (nombre, apellido, telefono, direccion, estado) " +
                                   "VALUES (@nombre, @apellido, @telefono, @direccion, @estado)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@estado", cliente.Estado);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar cliente: " + ex.Message);
            }
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection con = conexion.ObtenerConexion())
                {
                    string query = "UPDATE Clientes SET nombre=@nombre, apellido=@apellido, telefono=@telefono, direccion=@direccion, estado=@estado " +
                                   "WHERE id_cliente=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", cliente.IdCliente);
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@estado", cliente.Estado);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cliente: " + ex.Message);
            }
        }

        public bool EliminarCliente(int idCliente)
        {
            try
            {
                using (SqlConnection con = conexion.ObtenerConexion())
                {
                    string query = "DELETE FROM Clientes WHERE id_cliente=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idCliente);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cliente: " + ex.Message);
            }
        }

        public bool CambiarEstadoCliente(int idCliente, string nuevoEstado)
        {
            try
            {
                using (SqlConnection con = conexion.ObtenerConexion())
                {
                    string query = "UPDATE Clientes SET estado=@estado WHERE id_cliente=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    cmd.Parameters.AddWithValue("@estado", nuevoEstado);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar estado del cliente: " + ex.Message);
            }
        }

       
    }
}