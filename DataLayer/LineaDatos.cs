using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

using System.Data;

namespace DataLayer
{
    public class LineaDatos
    {
        private Conexion conexion = new Conexion();
        public List<Linea> ObtenerLineas()
        {
            List<Linea> lineas = new List<Linea>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_linea, nombre FROM Lineas", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Linea linea = new Linea
                    {
                        IdLinea = Convert.ToInt32(reader["id_linea"]),
                        NombreLinea = reader["nombre"].ToString()
                    };
                    lineas.Add(linea);
                }
            }
            return lineas;
        }

        public void AgregarLinea(string nombreLinea)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Lineas (nombre) VALUES (@Nombre)", con);
                cmd.Parameters.AddWithValue("@Nombre", nombreLinea);
                cmd.ExecuteNonQuery();
            }
        }

        public void EditarLinea(int idLinea, string nuevoNombre)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Linea SET nombre = @Nombre WHERE id_linea = @IdLinea", con);
                cmd.Parameters.AddWithValue("@Nombre", nuevoNombre);
                cmd.Parameters.AddWithValue("@IdLinea", idLinea);
                cmd.ExecuteNonQuery();
            }
        }

        public bool EliminarLinea(int idLinea)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
              
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Producto WHERE id_linea = @IdLinea", con);
                checkCmd.Parameters.AddWithValue("@IdLinea", idLinea);
                int productosAsociados = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (productosAsociados == 0)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Lineas WHERE id_linea = @IdLinea", con);
                    cmd.Parameters.AddWithValue("@IdLinea", idLinea);
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