using DataLayer;
using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNLayer
{
    public class RolNegocio
    {
        private RolDatos rolDatos = new RolDatos();

   
        public List<Rol> ObtenerRoles()
        {
            return rolDatos.ObtenerRoles();
        }

        
        public Rol ObtenerRolPorId(int idRol)
        {
            return rolDatos.ObtenerRolPorId(idRol);
        }
    }

}
