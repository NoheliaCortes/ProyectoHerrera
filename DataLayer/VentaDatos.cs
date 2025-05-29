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





    }

}
