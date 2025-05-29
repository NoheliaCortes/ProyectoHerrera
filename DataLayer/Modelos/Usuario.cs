using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Modelos
{
    public class Usuario
    {
        public int IdUsuario { get; set; }  
        public string NombreUsuario { get; set; }  
        public string ApellidoUsuario { get; set; }  
        public string Clave { get; set; }  
        public int IdRol { get; set; }  
        public bool Estado { get; set; } 

        public string Correo { get; set; }

       
        public Usuario() { }


        public Usuario(int idUsuario, string nombreUsuario, string apellidoUsuario, string clave, int idRol, bool estado, string correo)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            ApellidoUsuario = apellidoUsuario;
            Clave = clave;
            IdRol = idRol;
            Estado = estado;
            Correo = correo;
        }
    }

}
