using DataLayer.Modelos;
using System;
using System.Collections.Generic;
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
    }
}