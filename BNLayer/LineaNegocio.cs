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
            
            return lineaDatos.ObtenerLineas();
        }

        public void AgregarLinea(string nombreLinea)
        {
            lineaDatos.AgregarLinea(nombreLinea); 
        }

       

        public bool EliminarLinea(int idLinea)
        {
            return lineaDatos.EliminarLinea(idLinea); 
        }





    }

}
