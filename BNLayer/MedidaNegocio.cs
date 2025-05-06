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
    public class MedidaNegocio
    {
        private MedidaDatos medidaDatos = new MedidaDatos();

        public List<Medida> ObtenerMedidas()
        {
            return medidaDatos.ObtenerMedidas();
        }

        public DataTable ObtenerMedidasPorSabor(int idSabor)
        {
            MedidaDatos medidaDatos = new MedidaDatos();
            return medidaDatos.ObtenerMedidasPorSabor(idSabor);
        }




    }
}
