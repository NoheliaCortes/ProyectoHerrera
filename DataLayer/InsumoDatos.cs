using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class InsumoDatos
    {
        private Conexion conexion = new Conexion();

        public List<InsumoConCategoria> ObtenerInsumosConCategoria()
        {
            List<InsumoConCategoria> listaInsumosConCategoria = new List<InsumoConCategoria>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"SELECT i.id_insumo, i.nombre_insumo, c.nombre_categoria, m.nombre AS nombre_medida, s.cantidad AS stock
                         FROM Insumos i
                         INNER JOIN Categoria_Insumo c ON i.id_categoria = c.id_categoria
                         INNER JOIN Medidas m ON i.id_medida = m.id_medida
                         LEFT JOIN StockInsumos s ON i.id_insumo = s.id_insumo";  // ✅ Agregamos el stock

                SqlCommand cmd = new SqlCommand(query, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaInsumosConCategoria.Add(new InsumoConCategoria
                        {
                            IdInsumo = Convert.ToInt32(reader["id_insumo"]),
                            NombreInsumo = reader["nombre_insumo"].ToString(),
                            Categoria = reader["nombre_categoria"].ToString(),
                            Medida = reader["nombre_medida"].ToString(),
                            Stock = reader["stock"] != DBNull.Value ? Convert.ToInt32(reader["stock"]) : 0 // ✅ Si `stock` es NULL, asignar 0
                        });
                    }
                }
            }

            return listaInsumosConCategoria;
        }






        public bool InsertarInsumo(Insumo insumo)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "INSERT INTO Insumos (nombre_insumo, id_categoria, id_medida) VALUES (@Nombre, @Categoria, @Medida)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", insumo.NombreInsumo);
                cmd.Parameters.AddWithValue("@Categoria", insumo.IdCategoria);
                cmd.Parameters.AddWithValue("@Medida", insumo.IdMedida);

                return cmd.ExecuteNonQuery() > 0; // ✅ Devuelve `true` si la inserción fue exitosa
            }
        }

        

        public bool ActualizarInsumo(Insumo insumo)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "UPDATE Insumos SET nombre_insumo = @Nombre, id_categoria = @Categoria, id_medida = @Medida WHERE id_insumo = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", insumo.NombreInsumo);
                cmd.Parameters.AddWithValue("@Categoria", insumo.IdCategoria);
                cmd.Parameters.AddWithValue("@Medida", insumo.IdMedida);
                cmd.Parameters.AddWithValue("@Id", insumo.IdInsumo);

                return cmd.ExecuteNonQuery() > 0; // ✅ Devuelve `true` si la actualización fue exitosa
            }
        }

        public bool EliminarInsumo(int idInsumo)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "DELETE FROM Insumos WHERE id_insumo = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", idInsumo);

                return cmd.ExecuteNonQuery() > 0; 
            }
        }

        public bool ExisteInsumo(string nombreInsumo)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM Insumos WHERE nombre_insumo = @Nombre";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", nombreInsumo);

                int count = Convert.ToInt32(cmd.ExecuteScalar()); // ✅ Obtiene el número de registros con ese nombre
                return count > 0; // ✅ Si existe, devuelve `true`
            }
        }

        public bool ActualizarStock(int idInsumo, int nuevaCantidad)
        {
            
            
                using (SqlConnection con = conexion.ObtenerConexion())
                {
                   

                    // 🔍 **Verificar si el insumo ya tiene un registro en `StockInsumos`**
                    string verificarQuery = "SELECT COUNT(*) FROM StockInsumos WHERE id_insumo = @IdInsumo";
                    using (SqlCommand verificarCmd = new SqlCommand(verificarQuery, con))
                    {
                        verificarCmd.Parameters.AddWithValue("@IdInsumo", idInsumo);
                        int existe = Convert.ToInt32(verificarCmd.ExecuteScalar());

                        if (existe == 0)
                        {
                            // 🆕 **Si no existe, insertar el nuevo stock**
                            string insertarQuery = "INSERT INTO StockInsumos (id_insumo, cantidad) VALUES (@IdInsumo, @Cantidad)";
                            using (SqlCommand insertarCmd = new SqlCommand(insertarQuery, con))
                            {
                                insertarCmd.Parameters.AddWithValue("@IdInsumo", idInsumo);
                                insertarCmd.Parameters.AddWithValue("@Cantidad", nuevaCantidad);
                                insertarCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // 🔄 **Si ya existe, actualizar el stock**
                            string actualizarQuery = "UPDATE StockInsumos SET cantidad = @Cantidad WHERE id_insumo = @IdInsumo";
                            using (SqlCommand actualizarCmd = new SqlCommand(actualizarQuery, con))
                            {
                                actualizarCmd.Parameters.AddWithValue("@Cantidad", nuevaCantidad);
                                actualizarCmd.Parameters.AddWithValue("@IdInsumo", idInsumo);
                                actualizarCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                return true; // ✅ Operación exitosa
            
            
        }

        public List<Insumo> ObtenerInsumosPorCategoria(int idCategoria)
        {
            List<Insumo> insumos = new List<Insumo>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT id_insumo, nombre_insumo, id_medida, id_categoria FROM Insumos WHERE id_categoria = @IdCategoria";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            insumos.Add(new Insumo
                            {
                                IdInsumo = Convert.ToInt32(reader["id_insumo"]),
                                NombreInsumo = reader["nombre_insumo"].ToString(),
                                IdMedida = Convert.ToInt32(reader["id_medida"]),
                                IdCategoria = Convert.ToInt32(reader["id_categoria"])
                            });
                        }
                    }
                }
            }

            return insumos;
        }

        public string ObtenerMedidaInsumo(int idInsumo)
        {
            string medida = "";

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT nombre FROM Medidas WHERE id_medida = (SELECT id_medida FROM Insumos WHERE id_insumo = @IdInsumo)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdInsumo", idInsumo);

                    object resultado = cmd.ExecuteScalar(); // ✅ Obtener solo un valor
                    if (resultado != null)
                    {
                        medida = resultado.ToString();
                    }
                }
            }

            return medida;
        }




    }
}
