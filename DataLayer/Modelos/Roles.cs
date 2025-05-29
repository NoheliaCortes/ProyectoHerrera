using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Modelos
{
    public class Rol
    {
        public int IdRol { get; set; }  
        public string TipoRol { get; set; }  

  
        public Rol() { }

 
        public Rol(int idRol, string tipoRol)
        {
            IdRol = idRol;
            TipoRol = tipoRol;
        }
    }

}
