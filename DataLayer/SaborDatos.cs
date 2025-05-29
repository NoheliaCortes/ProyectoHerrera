using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SaborDatos
    {
        private Conexion conexion = new Conexion();

        public List<Sabor> ObtenerSabores()
        {
            List<Sabor> sabores = new List<Sabor>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_sabor, nombre_sabor FROM Sabores", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Sabor sabor = new Sabor
                    {
                        IdSabor = Convert.ToInt32(reader["id_sabor"]),
                        NombreSabor = reader["nombre_sabor"].ToString()
                    };
                    sabores.Add(sabor);
                }
            }
            return sabores;
        }


        public DataTable ObtenerSaboresPorLinea(int idLinea)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(@"
                SELECT id_sabor, nombre_sabor 
                FROM Sabores 
                WHERE id_linea = @idLinea", con);

                cmd.Parameters.AddWithValue("@idLinea", idLinea);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public void AgregarSabor(int idLinea, string nombreSabor)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Sabores WHERE nombre_sabor = @Nombre AND id_linea = @IdLinea", con);
                checkCmd.Parameters.AddWithValue("@Nombre", nombreSabor);
                checkCmd.Parameters.AddWithValue("@IdLinea", idLinea);
                int existe = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (existe == 0)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Sabores (nombre_sabor, id_linea) VALUES (@Nombre, @IdLinea)", con);
                    cmd.Parameters.AddWithValue("@Nombre", nombreSabor);
                    cmd.Parameters.AddWithValue("@IdLinea", idLinea);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("El sabor ya existe en esta línea.");
                }
            }
        }

        public bool EliminarSabor(int idSabor)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Producto WHERE id_sabor = @IdSabor", con);
                checkCmd.Parameters.AddWithValue("@IdSabor", idSabor);
                int productosAsociados = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (productosAsociados == 0)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Sabores WHERE id_sabor = @IdSabor", con);
                    cmd.Parameters.AddWithValue("@IdSabor", idSabor);
                    cmd.ExecuteNonQuery();
                    return true; 
                }
                else
                {
                    return false; 
                }
            }
        }




    }
}
