using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MovimientoStockDatos
    {

        private Conexion conexion = new Conexion();


        public bool RegistrarMovimientoStock(MovimientoStock movimiento)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"
        INSERT INTO Movimiento_Stock (id_producto, id_tipo_movimiento, id_usuario, cantidad, stock_anterior, stock_posterior, fecha, motivo_movimiento)
        VALUES (@idProducto, @idTipoMovimiento, @idUsuario, @cantidadMovida, @stockAnterior, @stockPosterior, GETDATE(), @motivoMovimiento)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idProducto", movimiento.IdProducto);
                    cmd.Parameters.AddWithValue("@idTipoMovimiento", movimiento.IdTipoMovimiento);
                    cmd.Parameters.AddWithValue("@idUsuario", movimiento.IdUsuario);
                    cmd.Parameters.AddWithValue("@cantidadMovida", movimiento.CantidadMovida);
                    cmd.Parameters.AddWithValue("@stockAnterior", movimiento.StockAnterior);
                    cmd.Parameters.AddWithValue("@stockPosterior", movimiento.StockPosterior);
                    cmd.Parameters.AddWithValue("@motivoMovimiento", string.IsNullOrEmpty(movimiento.MotivoMovimiento) ? (object)DBNull.Value : movimiento.MotivoMovimiento);

                    
                    return cmd.ExecuteNonQuery() > 0; // ✅ Retorna `true` si se guardó correctamente
                }
            }
        }


        public List<MovimientoStockInfo> ObtenerMovimientosStock()
        {
            List<MovimientoStockInfo> movimientos = new List<MovimientoStockInfo>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"
            SELECT 
                ms.id_movimiento, 
                p.nombre_producto AS producto,
                tm.nombre_tipo AS tipo_movimiento,
                u.nombre_usuario AS usuario,
                ms.cantidad, 
                ms.stock_anterior, 
                ms.stock_posterior, 
                ms.fecha, 
                ms.motivo_movimiento 
            FROM Movimiento_Stock ms
            INNER JOIN Producto p ON ms.id_producto = p.id_producto
            INNER JOIN Tipo_Movimiento tm ON ms.id_tipo_movimiento = tm.id_tipo_movimiento
            INNER JOIN Usuarios u ON ms.id_usuario = u.id_usuario
            ORDER BY ms.fecha DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movimientos.Add(new MovimientoStockInfo
                        {
                            IdMovimiento = Convert.ToInt32(reader["id_movimiento"]),
                            Producto = reader["producto"].ToString(),
                            TipoMovimiento = reader["tipo_movimiento"].ToString(),
                            Usuario = reader["usuario"].ToString(),
                            CantidadMovida = Convert.ToInt32(reader["cantidad"]),
                            StockAnterior = Convert.ToInt32(reader["stock_anterior"]),
                            StockPosterior = Convert.ToInt32(reader["stock_posterior"]),
                            FechaMovimiento = Convert.ToDateTime(reader["fecha"]),
                            MotivoMovimiento = reader["motivo_movimiento"].ToString()
                        });
                    }
                }
            }

            return movimientos;
        }



        public List<MovimientoStock> ObtenerMovimientosPorFiltro(DateTime? fechaInicio, DateTime? fechaFin, int? idUsuario, int? idProducto, int? idTipoMovimiento)
        {
            List<MovimientoStock> movimientos = new List<MovimientoStock>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"SELECT id_movimiento, id_producto, id_tipo_movimiento, id_usuario, cantidad, 
                                stock_anterior, stock_posterior, fecha, motivo_movimiento 
                         FROM Movimiento_Stock WHERE 1 = 1"; // ✅ `WHERE 1 = 1` facilita agregar condiciones dinámicas

                if (fechaInicio.HasValue && fechaFin.HasValue)
                    query += " AND fecha BETWEEN @FechaInicio AND @FechaFin";
                if (idUsuario.HasValue)
                    query += " AND id_usuario = @IdUsuario";
                if (idProducto.HasValue)
                    query += " AND id_producto = @IdProducto";
                if (idTipoMovimiento.HasValue)
                    query += " AND id_tipo_movimiento = @IdTipoMovimiento";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (fechaInicio.HasValue && fechaFin.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio.Value);
                        cmd.Parameters.AddWithValue("@FechaFin", fechaFin.Value);
                    }
                    if (idUsuario.HasValue)
                        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario.Value);
                    if (idProducto.HasValue)
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto.Value);
                    if (idTipoMovimiento.HasValue)
                        cmd.Parameters.AddWithValue("@IdTipoMovimiento", idTipoMovimiento.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movimientos.Add(new MovimientoStock
                            {
                                IdMovimiento = Convert.ToInt32(reader["id_movimiento"]),
                                IdProducto = Convert.ToInt32(reader["id_producto"]),
                                IdTipoMovimiento = Convert.ToInt32(reader["id_tipo_movimiento"]),
                                IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                                CantidadMovida = Convert.ToInt32(reader["cantidad"]),
                                StockAnterior = Convert.ToInt32(reader["stock_anterior"]),
                                StockPosterior = Convert.ToInt32(reader["stock_posterior"]),
                                FechaMovimiento = Convert.ToDateTime(reader["fecha"]),
                                MotivoMovimiento = reader["motivo_movimiento"].ToString()
                            });
                        }
                    }
                }
            }

            return movimientos;
        }


    }
}
