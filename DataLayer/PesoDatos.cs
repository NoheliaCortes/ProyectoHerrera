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
   
    public class PesoDatos
    {
        private Conexion conexion = new Conexion();
        public List<Peso> ObtenerPesos()
        {
            List<Peso> pesos = new List<Peso>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_peso, peso FROM Pesos", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Peso peso = new Peso
                    {
                        IdPeso = Convert.ToInt32(reader["id_peso"]),
                        NombrePeso = reader["peso"].ToString()
                    };
                    pesos.Add(peso);
                }
            }
            return pesos;
        }

        public DataTable ObtenerPesosPorMedida(int idMedida)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_peso, nombre_peso FROM Peso WHERE id_medida = @idMedida", con);
                cmd.Parameters.AddWithValue("@idMedida", idMedida);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }



    }
}