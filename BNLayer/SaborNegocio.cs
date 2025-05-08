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
    public class SaborNegocio
    {
        private SaborDatos saborDatos = new SaborDatos();

        public List<Sabor> ObtenerSabores()
        {
            return saborDatos.ObtenerSabores();
        }

        public DataTable ObtenerSaboresPorLinea(int idLinea)
        {
            SaborDatos saborDatos = new SaborDatos();
            return saborDatos.ObtenerSaboresPorLinea(idLinea);
        }

    }
}
