using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class VentaDatos
    {
        public class ClienteDatos
        {
            private Conexion conexion = new Conexion(); // ✅ Conexión a la BD

            public void AgregarCliente(Cliente cliente)
            {
                using (SqlConnection con = conexion.ObtenerConexion())
                {
                    string query = @"INSERT INTO Clientes (nombre, apellido, telefono, direccion) 
                                 VALUES (@nombre, @apellido, @telefono, @direccion)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    cmd.ExecuteNonQuery();
                }
            }

            public List<Cliente> ObtenerClientes()
            {
                List<Cliente> clientes = new List<Cliente>();

                using (SqlConnection con = conexion.ObtenerConexion())
                {
                    string query = "SELECT id_cliente, nombre, apellido, telefono, direccion FROM Clientes";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            IdCliente = Convert.ToInt32(reader["id_cliente"]),
                            Nombre = reader["nombre"].ToString(),
                            Apellido = reader["apellido"].ToString(),
                            Telefono = reader["telefono"].ToString(),
                            Direccion = reader["direccion"] != DBNull.Value ? reader["direccion"].ToString() : ""
                        };
                        clientes.Add(cliente);
                    }
                }
                return clientes;
            }

            public void EditarCliente(Cliente cliente)
            {
                using (SqlConnection con = conexion.ObtenerConexion())
                {
                    string query = @"UPDATE Clientes 
                                 SET nombre = @nombre, apellido = @apellido, 
                                     telefono = @telefono, direccion = @direccion 
                                 WHERE id_cliente = @idCliente";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@idCliente", cliente.IdCliente);
                    cmd.ExecuteNonQuery();
                }
            }

            public void EliminarCliente(int idCliente)
            {
                using (SqlConnection con = conexion.ObtenerConexion())
                {
                    string query = "DELETE FROM Clientes WHERE id_cliente = @idCliente";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
