using DataLayer.Modelos;
using System;
using System.Collections.Generic;
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
    }
}
