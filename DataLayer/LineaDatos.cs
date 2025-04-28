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
    }

}