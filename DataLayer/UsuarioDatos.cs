using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UsuarioDatos
    {
        private Conexion conexion = new Conexion();


        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Usuarios";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listaUsuarios.Add(new Usuario
                    {
                        IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                        NombreUsuario = reader["nombre_usuario"].ToString(),
                        ApellidoUsuario = reader["apellido_usuario"].ToString(),
                        Clave = reader["clave"].ToString(),
                        IdRol = Convert.ToInt32(reader["id_rol"]),
                        Estado = Convert.ToBoolean(reader["estado"]),
                        Correo = reader["correo"].ToString()
                    });
                }
            }
            return listaUsuarios;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"
            INSERT INTO Usuarios (nombre_usuario, apellido_usuario, clave, id_rol, estado, correo) 
            VALUES (@nombre, @apellido, @clave, @idRol, @estado, @correo)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nombre", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@apellido", usuario.ApellidoUsuario);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave); 
                cmd.Parameters.AddWithValue("@idRol", usuario.IdRol);
                cmd.Parameters.AddWithValue("@estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Usuarios WHERE id_usuario = @idUsuario";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Usuario
                    {
                        IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                        NombreUsuario = reader["nombre_usuario"].ToString(),
                        ApellidoUsuario = reader["apellido_usuario"].ToString(),
                        Clave = reader["clave"].ToString(),
                        IdRol = Convert.ToInt32(reader["id_rol"]),
                        Estado = Convert.ToBoolean(reader["estado"]),
                        Correo = reader["correo"].ToString()
                    };
                }
                return null;
            }
        }

        public Usuario ObtenerUsuarioPorCorreo(string correo)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Usuarios WHERE correo = @correo";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@correo", correo);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Usuario
                    {
                        IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                        NombreUsuario = reader["nombre_usuario"].ToString(),
                        ApellidoUsuario = reader["apellido_usuario"].ToString(),
                        Correo = reader["correo"].ToString(),
                        Clave = reader["clave"].ToString(),
                        IdRol = Convert.ToInt32(reader["id_rol"]),
                        Estado = Convert.ToBoolean(reader["estado"])
                    };
                }
                return null;
            }
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"
            UPDATE Usuarios 
            SET nombre_usuario = @nombre, apellido_usuario = @apellido, clave = @clave, id_rol = @idRol, estado = @estado, correo = @correo
            WHERE id_usuario = @idUsuario";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nombre", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@apellido", usuario.ApellidoUsuario);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@idRol", usuario.IdRol);
                cmd.Parameters.AddWithValue("@estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);


                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public bool EliminarUsuario(int idUsuario)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "DELETE FROM Usuarios WHERE id_usuario = @idUsuario";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

}
