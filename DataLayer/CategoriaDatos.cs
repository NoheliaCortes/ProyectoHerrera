using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CategoriaDatos
    {

        private Conexion conexion = new Conexion();


        public bool InsertarCategoria(CategoriaInsumo categoria)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "INSERT INTO Categoria_Insumo (nombre_categoria) VALUES (@Nombre)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", categoria.NombreCategoria);

                return cmd.ExecuteNonQuery() > 0; 
            }
        }

        public List<CategoriaInsumo> ObtenerCategorias()
        {
            List<CategoriaInsumo> listaCategorias = new List<CategoriaInsumo>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT id_categoria, nombre_categoria FROM Categoria_Insumo";
                SqlCommand cmd = new SqlCommand(query, con);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaCategorias.Add(new CategoriaInsumo
                        {
                            IdCategoria = Convert.ToInt32(reader["id_categoria"]),
                            NombreCategoria = reader["nombre_categoria"].ToString()
                        });
                    }
                }
            }

            return listaCategorias; 
        }

        public bool ActualizarCategoria(CategoriaInsumo categoria)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "UPDATE Categoria_Insumo SET nombre_categoria = @Nombre WHERE id_categoria = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", categoria.NombreCategoria);
                cmd.Parameters.AddWithValue("@Id", categoria.IdCategoria);

                return cmd.ExecuteNonQuery() > 0; 
            }
        }

        public bool EliminarCategoria(int idCategoria)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "DELETE FROM Categoria_Insumo WHERE id_categoria = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", idCategoria);

                return cmd.ExecuteNonQuery() > 0; 
            }
        }




    }
}
