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
        private Conexion conexion = new Conexion();

        public int RegistrarVenta(decimal total, int idCliente, int idUsuario)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"
                INSERT INTO Venta (fecha, total, id_cliente, id_usuario) 
                OUTPUT INSERTED.id_venta
                VALUES (@fecha, @total, @idCliente, @idUsuario)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                return Convert.ToInt32(cmd.ExecuteScalar()); 
            }
        }

        public void RegistrarDetalleVenta(int idVenta, int idProducto, int cantidad, decimal subtotal)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"
                INSERT INTO Detalle_Venta (id_venta, id_producto, cantidad, subtotal) 
                VALUES (@idVenta, @idProducto, @cantidad, @subtotal)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@subtotal", subtotal);

                cmd.ExecuteNonQuery();
            }
        }

        public void DescontarStock(int idProducto, int cantidadVendida)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"
        UPDATE StockActual 
        SET cantidad = cantidad - @cantidadVendida 
        WHERE id_producto = @idProducto";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@cantidadVendida", cantidadVendida);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.ExecuteNonQuery();
            }
        }



        public int ObtenerIdProducto(string nombreProducto)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
               
                string query = "SELECT id_producto FROM Producto WHERE nombre_producto = @nombreProducto";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        public DataTable ObtenerHistorialVentas()
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT v.id_venta AS idVenta, v.fecha AS Fecha,  v.total AS Total, c.nombre + ' ' + c.apellido AS Cliente, u.nombre_usuario + ' ' + u.apellido_usuario AS Usuario FROM Venta v LEFT JOIN Clientes c ON v.id_cliente = c.id_cliente LEFT JOIN Usuarios u ON v.id_usuario = u.id_usuario ORDER BY v.fecha DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public DataTable ObtenerVentasPorFiltro(DateTime? fechaInicio, DateTime? fechaFin, int? idCliente, int? idUsuario)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"SELECT v.id_venta AS idVenta, v.fecha AS Fecha, v.total AS Total,
                                c.nombre + ' ' + c.apellido AS Cliente, 
                                u.nombre_usuario + ' ' + u.apellido_usuario AS Usuario
                         FROM Venta v
                         LEFT JOIN Clientes c ON v.id_cliente = c.id_cliente
                         LEFT JOIN Usuarios u ON v.id_usuario = u.id_usuario
                         WHERE 1 = 1"; // ✅ Base para filtros dinámicos

                if (fechaInicio.HasValue && fechaFin.HasValue)
                {
                    query += " AND v.fecha BETWEEN @FechaInicio AND @FechaFin";
                }
                if (idCliente.HasValue)
                {
                    query += " AND v.id_cliente = @IdCliente"; // ✅ Busca por ID de cliente
                }
                if (idUsuario.HasValue)
                {
                    query += " AND v.id_usuario = @IdUsuario"; // ✅ Busca por ID de usuario
                }

                query += " ORDER BY v.fecha DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                if (fechaInicio.HasValue && fechaFin.HasValue)
                {
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio.Value);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin.Value);
                }
                if (idCliente.HasValue)
                {
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente.Value);
                }
                if (idUsuario.HasValue)
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario.Value);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }






        public VentaInfo ObtenerVentaPorId(int idVenta)
        {
            VentaInfo venta = null;
            using (SqlConnection con = conexion.ObtenerConexion())
             {
       
             using (SqlCommand cmd = new SqlCommand(@"SELECT v.fecha, v.total, u.nombre_usuario, c.nombre
                                                 FROM Venta v
                                                 INNER JOIN Usuarios u ON v.id_usuario = u.id_usuario
                                                 INNER JOIN Clientes c ON v.id_cliente = c.id_cliente
                                                 WHERE v.id_venta = @IdVenta", con))
            {
            cmd.Parameters.AddWithValue("@IdVenta", idVenta);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    venta = new VentaInfo
                    {
                        FechaVenta = Convert.ToDateTime(reader["fecha"]),
                        Total = Convert.ToDecimal(reader["total"]),
                        Usuario = reader["nombre_usuario"].ToString(),
                        Cliente = reader["nombre"].ToString()
                    };
                }
            }
            }
            }
    return venta;
}

        public DataTable ObtenerDetalleVenta(int idVenta)
            {
                using (SqlConnection con = conexion.ObtenerConexion())
                {
                    string query = @"
            SELECT p.nombre_producto, dv.cantidad, p.precio_producto, dv.subtotal
            FROM Detalle_Venta dv
            INNER JOIN Producto p ON dv.id_producto = p.id_producto
            WHERE dv.id_venta = @idVenta";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }

}
