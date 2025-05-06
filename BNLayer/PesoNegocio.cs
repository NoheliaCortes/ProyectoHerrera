using DataLayer.Modelos;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BNLayer
{
    public class PesoNegocio
    {
        private PesoDatos pesoDatos = new PesoDatos();

        public List<Peso> ObtenerPesos()
        {
            return pesoDatos.ObtenerPesos();
        }

        public DataTable ObtenerPesosPorMedida(int idMedida)
        {
            PesoDatos pesoDatos = new PesoDatos();
            return pesoDatos.ObtenerPesosPorMedida(idMedida);
        }





    }

}
