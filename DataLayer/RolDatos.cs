using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RolDatos
    {
        private Conexion conexion = new Conexion();

      
        public List<Rol> ObtenerRoles()
        {
            List<Rol> listaRoles = new List<Rol>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT id_rol, tipo_rol FROM Roles";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listaRoles.Add(new Rol
                    {
                        IdRol = Convert.ToInt32(reader["id_rol"]),
                        TipoRol = reader["tipo_rol"].ToString()
                    });
                }
            }
            return listaRoles;
        }

        
        public Rol ObtenerRolPorId(int idRol)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT id_rol, tipo_rol FROM Roles WHERE id_rol = @idRol";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idRol", idRol);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Rol
                    {
                        IdRol = Convert.ToInt32(reader["id_rol"]),
                        TipoRol = reader["tipo_rol"].ToString()
                    };
                }
                return null;
            }
        }
    }
}
