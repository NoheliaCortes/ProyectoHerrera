using DataLayer.Modelos;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNLayer
{
    public class PesoNegocio
    {
        private PesoDatos pesoDatos = new PesoDatos();

        public List<Peso> ObtenerPesos()
        {
            return pesoDatos.ObtenerPesos();
        }
    }
}
