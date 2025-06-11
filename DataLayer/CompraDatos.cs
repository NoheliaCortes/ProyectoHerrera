using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CompraDatos
    {
        private Conexion conexion = new Conexion();


        public bool RegistrarCompra(Compra compra)
        {
           
                using (SqlConnection con = conexion.ObtenerConexion())
                {
                 
                    SqlTransaction transaccion = con.BeginTransaction(); // ✅ Iniciar transacción para garantizar integridad de datos

                    // 🔹 Insertar la compra
                    string queryCompra = "INSERT INTO Compras (id_proveedor, fecha, total) OUTPUT INSERTED.id_compra VALUES (@IdProveedor, @Fecha, @Total)";
                    int idCompra;
                    using (SqlCommand cmdCompra = new SqlCommand(queryCompra, con, transaccion))
                    {
                        cmdCompra.Parameters.AddWithValue("@IdProveedor", compra.IdProveedor);
                        cmdCompra.Parameters.AddWithValue("@Fecha", compra.Fecha);
                        cmdCompra.Parameters.AddWithValue("@Total", compra.Total);
                        idCompra = (int)cmdCompra.ExecuteScalar(); // ✅ Obtener el `id_compra` generado
                    }

                    // 🔹 Insertar los detalles de compra
                    string queryDetalle = "INSERT INTO Detalle_Compra (id_compra, id_insumo, cantidad, precio_unitario) VALUES (@IdCompra, @IdInsumo, @Cantidad, @PrecioUnitario)";
                    foreach (var detalle in compra.Detalles)
                    {
                        using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, con, transaccion))
                        {
                            cmdDetalle.Parameters.AddWithValue("@IdCompra", idCompra);
                            cmdDetalle.Parameters.AddWithValue("@IdInsumo", detalle.IdInsumo);
                            cmdDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                            cmdDetalle.ExecuteNonQuery();
                        }
                    }

                    transaccion.Commit(); // ✅ Confirmar cambios
                    return true;
                }
        }

        public List<Compra> ObtenerCompras()
        {
            List<Compra> compras = new List<Compra>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT id_compra, id_proveedor, fecha, total FROM Compras ORDER BY fecha DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        compras.Add(new Compra
                        {
                            IdCompra = Convert.ToInt32(reader["id_compra"]),
                            IdProveedor = Convert.ToInt32(reader["id_proveedor"]),
                            Fecha = Convert.ToDateTime(reader["fecha"]),
                            Total = Convert.ToDecimal(reader["total"])
                        });
                    }
                }
            }

            return compras;
        }

        public List<DetalleCompra> ObtenerDetallesCompra(int idCompra)
        {
            List<DetalleCompra> detalles = new List<DetalleCompra>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT id_detalle_compra, id_compra, id_insumo, cantidad, precio_unitario FROM Detalle_Compra WHERE id_compra = @IdCompra";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdCompra", idCompra);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            detalles.Add(new DetalleCompra
                            {
                                IdDetalleCompra = Convert.ToInt32(reader["id_detalle_compra"]),
                                IdCompra = Convert.ToInt32(reader["id_compra"]),
                                IdInsumo = Convert.ToInt32(reader["id_insumo"]),
                                Cantidad = Convert.ToInt32(reader["cantidad"]),
                                PrecioUnitario = Convert.ToDecimal(reader["precio_unitario"])
                            });
                        }
                    }
                }
            }

            return detalles;
        }


        public List<ComprasInfo> ObtenerHistorialCompras()
        {
            List<ComprasInfo> compras = new List<ComprasInfo>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"
            SELECT c.id_compra, p.nombre, c.fecha, c.total 
            FROM Compras c
            INNER JOIN Proveedores p ON c.id_proveedor = p.id_proveedor
            ORDER BY c.fecha DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        compras.Add(new ComprasInfo
                        {
                            IdCompra = Convert.ToInt32(reader["id_compra"]),
                            Proveedor = reader["nombre"].ToString(),
                            Fecha = Convert.ToDateTime(reader["fecha"]),
                            Total = Convert.ToDecimal(reader["total"])
                        });
                    }
                }
            }

            foreach (var compra in compras)
            {
                compra.Detalles = ObtenerDetallesCompraInfo(compra.IdCompra);
            }

            return compras;
        }


        public List<DetalleCompraInfo> ObtenerDetallesCompraInfo(int idCompra)
        {
            List<DetalleCompraInfo> detalles = new List<DetalleCompraInfo>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"
            SELECT dc.id_detalle_compra, i.nombre_insumo, dc.cantidad, dc.precio_unitario
            FROM Detalle_Compra dc
            INNER JOIN Insumos i ON dc.id_insumo = i.id_insumo
            WHERE dc.id_compra = @IdCompra";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdCompra", idCompra);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            detalles.Add(new DetalleCompraInfo
                            {
                                IdDetalleCompra = Convert.ToInt32(reader["id_detalle_compra"]),
                                Insumo = reader["nombre_insumo"].ToString(),
                                Cantidad = Convert.ToInt32(reader["cantidad"]),
                                PrecioUnitario = Convert.ToDecimal(reader["precio_unitario"])
                            });
                        }
                    }
                }
            }

            return detalles;
        }





    }
}
