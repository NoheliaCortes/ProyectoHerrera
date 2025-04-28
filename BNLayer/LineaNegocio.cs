using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BNLayer;

namespace BNLayer
{
    public class LineaNegocio
    {
        private LineaDatos lineaDatos = new LineaDatos();

        public List<Linea> ObtenerLineas()
        {
            // Aquí podrías incluir validaciones o lógica adicional antes de llamar a la capa de datos
            return lineaDatos.ObtenerLineas();
        }
    }

}
