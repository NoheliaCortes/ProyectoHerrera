using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataLayer.Modelos;

namespace DataLayer
{
    public class ProveedorDatos
    {
        public List<Proveedor> ObtenerProveedores()
        {
            var lista = new List<Proveedor>();
            var cx = new Conexion();
            using (SqlConnection con = cx.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "SELECT Id_Proveedor, nombre, telefono FROM Proveedores",
                con))
            {
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var proveedor = new Proveedor
                            {
                                Id_Proveedor = reader.GetInt32(0),
                                nombre = reader.GetString(1),
                                telefono = reader.GetString(2)
                            };
                            lista.Add(proveedor);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener proveedores: {ex.Message}", ex);
                }
            }
            return lista;
        }

        public int AgregarProveedor(Proveedor p)
        {
            var cx = new Conexion();
            using (var con = cx.ObtenerConexion())
            using (var cmd = new SqlCommand(
                @"INSERT INTO Proveedores (nombre, telefono)
                  VALUES (@n,@t);
                  SELECT CAST(SCOPE_IDENTITY() AS int);",
                con))
            {
                cmd.Parameters.AddWithValue("@n", p.nombre);
                cmd.Parameters.AddWithValue("@t", p.telefono);
                return (int)cmd.ExecuteScalar();
            }
        }

        public void ActualizarProveedor(Proveedor p)
        {
            var cx = new Conexion();
            using (SqlConnection con = cx.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "UPDATE Proveedores SET nombre = @n, telefono = @t WHERE Id_Proveedor = @id",
                con))
            {
                cmd.Parameters.AddWithValue("@n", p.nombre);
                cmd.Parameters.AddWithValue("@t", p.telefono);
                cmd.Parameters.AddWithValue("@id", p.Id_Proveedor);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarProveedor(int id)
        {
            var cx = new Conexion();
            using (SqlConnection con = cx.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "DELETE FROM Proveedores WHERE Id_Proveedor = @id",
                con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Proveedor ObtenerProveedorPorId(int id)
        {
            var cx = new Conexion();
            using (var con = cx.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "SELECT Id_Proveedor, nombre, telefono FROM Proveedores WHERE Id_Proveedor=@id",
                con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        return new Proveedor
                        {
                            Id_Proveedor = r.GetInt32(0),
                            nombre = r.GetString(1),
                            telefono = r.GetString(2)
                        };
                    }
                }
            }
            return null;
        }
    }
}
