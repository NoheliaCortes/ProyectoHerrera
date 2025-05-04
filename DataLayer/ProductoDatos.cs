using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
                SqlCommand cmd = new SqlCommand("UPDATE StockActual SET cantidad = cantidad + @Cantidad WHERE id_producto = @IdProducto", con);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                cmd.ExecuteNonQuery();
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



    }

}
