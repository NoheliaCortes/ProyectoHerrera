using DataLayer.Modelos;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNLayer
{
    public class EnvaseNegocio
    {
        private EnvaseDatos envaseDatos = new EnvaseDatos();

        public List<Envase> ObtenerEnvases()
        {
            return envaseDatos.ObtenerEnvases();
        }
    }
}
