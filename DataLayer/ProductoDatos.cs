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
    public class ProductoDatos
    {
        private Conexion conexion = new Conexion();

        public List<ProductoConStock> ObtenerProductosConStock()
        {
            List<ProductoConStock> productos = new List<ProductoConStock>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(@"SELECT p.id_producto, p.nombre_producto, 
                                                  p.costo_produccion, p.precio_producto, 
                                                  s.cantidad
                                                  FROM Producto p
                                                  LEFT JOIN StockActual s ON p.id_producto = s.id_producto", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductoConStock producto = new ProductoConStock
                    {
                        IdProducto = Convert.ToInt32(reader["id_producto"]),
                        NombreProducto = reader["nombre_producto"].ToString(),
                        CostoProduccion = Convert.ToDecimal(reader["costo_produccion"]),
                        PrecioProducto = Convert.ToDecimal(reader["precio_producto"]),
                        Cantidad = reader["cantidad"] != DBNull.Value
                                             ? Convert.ToInt32(reader["cantidad"])
                                             : 0
                    };
                    productos.Add(producto);
                }
            }
            return productos;
        }

        public void InsertarProducto(Producto producto)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Producto 
                                          (nombre_producto, precio_producto, costo_produccion, descuento_producto, cantidad_minima_descuento, id_linea, id_sabor, id_peso, id_medida, id_envase)
                                          VALUES 
                                          (@NombreProducto, @PrecioProducto, @CostoProduccion, @DescuentoProducto, @CantidadMinimaDescuento, @IdLinea, @IdSabor, @IdPeso, @IdMedida, @IdEnvase)", con);
                cmd.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
                cmd.Parameters.AddWithValue("@PrecioProducto", producto.PrecioProducto);
                cmd.Parameters.AddWithValue("@CostoProduccion", producto.CostoProduccion);
                cmd.Parameters.AddWithValue("@DescuentoProducto", producto.DescuentoProducto);
                cmd.Parameters.AddWithValue("@CantidadMinimaDescuento", producto.CantidadMinimaDescuento);
                cmd.Parameters.AddWithValue("@IdLinea", producto.IdLinea);
                cmd.Parameters.AddWithValue("@IdSabor", producto.IdSabor);
                cmd.Parameters.AddWithValue("@IdPeso", producto.IdPeso);
                cmd.Parameters.AddWithValue("@IdMedida", producto.IdMedida);
                cmd.Parameters.AddWithValue("@IdEnvase", producto.IdEnvase);

                cmd.ExecuteNonQuery();
            }
        }

        public void ModificarStock(int idProducto, int cantidad)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM StockActual WHERE id_producto = @IdProducto", con);
                checkCmd.Parameters.AddWithValue("@IdProducto", idProducto);
                int existe = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (existe > 0)
                {
                    
                    SqlCommand updateCmd = new SqlCommand("UPDATE StockActual SET cantidad = cantidad + @Cantidad WHERE id_producto = @IdProducto", con);
                    updateCmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    updateCmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    
                    SqlCommand insertCmd = new SqlCommand("INSERT INTO StockActual (id_producto, cantidad) VALUES (@IdProducto, @Cantidad)", con);
                    insertCmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    insertCmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }


        public int ObtenerStockActual(int idProducto)
        {
            int stockActual = 0;
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT cantidad FROM StockActual WHERE id_producto = @IdProducto", con);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    stockActual = Convert.ToInt32(result);
                }
            }
            return stockActual;
        }

        public Producto ObtenerProductoPorId(int idProducto)
        {
            Producto producto = null;
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM Producto WHERE id_producto = @IdProducto", con);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    producto = new Producto
                    {
                        IdProducto = Convert.ToInt32(reader["id_producto"]),
                        NombreProducto = reader["nombre_producto"].ToString(),
                        PrecioProducto = Convert.ToDecimal(reader["precio_producto"]),
                        CostoProduccion = Convert.ToDecimal(reader["costo_produccion"]),
                        DescuentoProducto = Convert.ToDecimal(reader["descuento_producto"]),
                        CantidadMinimaDescuento = Convert.ToInt32(reader["cantidad_minima_descuento"]),
                        IdLinea = Convert.ToInt32(reader["id_linea"]),
                        IdSabor = Convert.ToInt32(reader["id_sabor"]),
                        IdPeso = Convert.ToInt32(reader["id_peso"]),
                        IdMedida = Convert.ToInt32(reader["id_medida"]),
                        IdEnvase = Convert.ToInt32(reader["id_envase"])
                    };
                }
            }
            return producto;
        }


        public void ActualizarProducto(Producto producto)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE Producto 
                                          SET nombre_producto = @NombreProducto, 
                                              precio_producto = @PrecioProducto, 
                                              costo_produccion = @CostoProduccion, 
                                              descuento_producto = @DescuentoProducto, 
                                              cantidad_minima_descuento = @CantidadMinimaDescuento, 
                                              id_linea = @IdLinea, 
                                              id_sabor = @IdSabor, 
                                              id_peso = @IdPeso, 
                                              id_medida = @IdMedida, 
                                              id_envase = @IdEnvase
                                          WHERE id_producto = @IdProducto", con);

                cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                cmd.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
                cmd.Parameters.AddWithValue("@PrecioProducto", producto.PrecioProducto);
                cmd.Parameters.AddWithValue("@CostoProduccion", producto.CostoProduccion);
                cmd.Parameters.AddWithValue("@DescuentoProducto", producto.DescuentoProducto);
                cmd.Parameters.AddWithValue("@CantidadMinimaDescuento", producto.CantidadMinimaDescuento);
                cmd.Parameters.AddWithValue("@IdLinea", producto.IdLinea);
                cmd.Parameters.AddWithValue("@IdSabor", producto.IdSabor);
                cmd.Parameters.AddWithValue("@IdPeso", producto.IdPeso);
                cmd.Parameters.AddWithValue("@IdMedida", producto.IdMedida);
                cmd.Parameters.AddWithValue("@IdEnvase", producto.IdEnvase);

                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarProducto(int idProducto)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
           
                SqlTransaction transaccion = con.BeginTransaction();

                try
                {
                    // ✅ Primero eliminar el stock del producto
                    SqlCommand cmdEliminarStock = new SqlCommand(@"
                DELETE FROM StockActual WHERE id_producto = @IdProducto", con, transaccion);

                    cmdEliminarStock.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmdEliminarStock.ExecuteNonQuery();

                    // ✅ Luego eliminar el producto de la tabla `Producto`
                    SqlCommand cmdEliminarProducto = new SqlCommand(@"
                DELETE FROM Producto WHERE id_producto = @IdProducto", con, transaccion);

                    cmdEliminarProducto.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmdEliminarProducto.ExecuteNonQuery();

                    transaccion.Commit();
                }
                catch
                {
                    transaccion.Rollback();
                }
            }
        }

        public DataTable ObtenerProductoPorFiltros(int idLinea, int idSabor, int idMedida, int idPeso)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_producto, nombre_producto, precio FROM Producto WHERE id_linea = @idLinea AND id_sabor = @idSabor AND id_medida = @idMedida AND id_peso = @idPeso", con);
                cmd.Parameters.AddWithValue("@idLinea", idLinea);
                cmd.Parameters.AddWithValue("@idSabor", idSabor);
                cmd.Parameters.AddWithValue("@idMedida", idMedida);
                cmd.Parameters.AddWithValue("@idPeso", idPeso);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable BuscarProductoConDescuento(int idLinea, int idSabor, int idMedida, int idPeso)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT id_producto, nombre_producto, precio_producto, descuento_producto, cantidad_minima_descuento 
            FROM Producto
            WHERE id_linea = @idLinea AND id_sabor = @idSabor AND id_medida = @idMedida AND id_peso = @idPeso", con);

                cmd.Parameters.AddWithValue("@idLinea", idLinea);
                cmd.Parameters.AddWithValue("@idSabor", idSabor);
                cmd.Parameters.AddWithValue("@idMedida", idMedida);
                cmd.Parameters.AddWithValue("@idPeso", idPeso);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public bool ExisteProducto(int idSabor, int idPeso)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT COUNT(*) FROM Producto
            WHERE id_sabor = @idSabor AND id_peso = @idPeso", con);

                cmd.Parameters.AddWithValue("@idSabor", idSabor);
                cmd.Parameters.AddWithValue("@idPeso", idPeso);

               
                int count = Convert.ToInt32(cmd.ExecuteScalar()); 
                return count > 0; 
            }
        }

        public List<ProductoConStock> FiltrarProductos(int idLinea, int idSabor, int idPeso, int idMedida)
        {
            List<ProductoConStock> productos = new List<ProductoConStock>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"SELECT p.id_producto, p.nombre_producto, 
                                p.costo_produccion, p.precio_producto, 
                                s.cantidad
                         FROM Producto p
                         LEFT JOIN StockActual s ON p.id_producto = s.id_producto
                         WHERE 1=1"; 

                List<SqlParameter> parametros = new List<SqlParameter>();

                if (idLinea > 0)
                {
                    query += " AND p.id_linea = @idLinea";
                    parametros.Add(new SqlParameter("@idLinea", idLinea));
                }
                if (idSabor > 0)
                {
                    query += " AND p.id_sabor = @idSabor";
                    parametros.Add(new SqlParameter("@idSabor", idSabor));
                }
                if (idPeso > 0)
                {
                    query += " AND p.id_peso = @idPeso";
                    parametros.Add(new SqlParameter("@idPeso", idPeso));
                }
                if (idMedida > 0)
                {
                    query += " AND p.id_medida = @idMedida";
                    parametros.Add(new SqlParameter("@idMedida", idMedida));
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddRange(parametros.ToArray());

               
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductoConStock producto = new ProductoConStock
                    {
                        IdProducto = Convert.ToInt32(reader["id_producto"]),
                        NombreProducto = reader["nombre_producto"].ToString(),
                        CostoProduccion = Convert.ToDecimal(reader["costo_produccion"]),
                        PrecioProducto = Convert.ToDecimal(reader["precio_producto"]),
                        Cantidad = reader["cantidad"] != DBNull.Value
                                               ? Convert.ToInt32(reader["cantidad"])
                                               : 0
                    };
                    productos.Add(producto);
                }
            }

            return productos; 
        }

        public bool VerificarStock(int idProducto, int cantidadVendida)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT cantidad FROM StockActual WHERE id_producto = @idProducto", con);

                cmd.Parameters.AddWithValue("@idProducto", idProducto);
             

                object result = cmd.ExecuteScalar();
                int stockDisponible = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                return stockDisponible >= cantidadVendida; 
            }
        }




    }

}
