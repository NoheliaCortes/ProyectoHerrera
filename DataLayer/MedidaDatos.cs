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
    public class MedidaDatos
    {
        private Conexion conexion = new Conexion();
        public List<Medida> ObtenerMedidas()
        {
            List<Medida> medidas = new List<Medida>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_medida, nombre FROM Medidas", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Medida medida = new Medida
                    {
                        IdMedida = Convert.ToInt32(reader["id_medida"]),
                        NombreMedida = reader["nombre"].ToString()
                    };
                    medidas.Add(medida);
                }
            }
            return medidas;
        }

        public DataTable ObtenerMedidasPorSabor(int idSabor)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_medida, nombre_medida FROM Medida WHERE id_sabor = @idSabor", con);
                cmd.Parameters.AddWithValue("@idSabor", idSabor);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }


    }
}