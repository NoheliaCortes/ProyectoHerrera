using DataLayer.Modelos;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNLayer
{
    public class UsuarioNegocio
    {
        private UsuarioDatos usuarioDatos = new UsuarioDatos();

        public bool RegistrarUsuario(Usuario usuario)
        {
            return usuarioDatos.RegistrarUsuario(usuario);
        }

        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            return usuarioDatos.ObtenerUsuarioPorId(idUsuario);
        }

        public Usuario ObtenerUsuarioPorCorreo(string correo)
        {
            return usuarioDatos.ObtenerUsuarioPorCorreo(correo);
        }
       
        public List<Usuario> ObtenerUsuarios()
        {
            return usuarioDatos.ObtenerUsuarios();
        }

        
        public bool ActualizarUsuario(Usuario usuario)
        {
            return usuarioDatos.ActualizarUsuario(usuario);
        }

        public bool EliminarUsuario(int idUsuario)
        {
            return usuarioDatos.EliminarUsuario(idUsuario);
        }
    }


}
