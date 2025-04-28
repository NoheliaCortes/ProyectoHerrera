using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EnvaseDatos
    {
        private Conexion conexion = new Conexion();

        public List<Envase> ObtenerEnvases()
        {
            List<Envase> envases = new List<Envase>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_envase, tipo_envase FROM Envases", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Envase envase = new Envase
                    {
                        IdEnvase = Convert.ToInt32(reader["id_envase"]),
                        TipoEnvase = reader["tipo_envase"].ToString()
                    };
                    envases.Add(envase);
                }
            }
            return envases;
        }
    }
}
