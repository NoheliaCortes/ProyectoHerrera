using DataLayer.Modelos;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNLayer
{
    public class InsumoNegocio
    {
        private InsumoDatos insumoDatos = new InsumoDatos(); 

        public bool InsertarInsumo(Insumo insumo)
        {
            if (insumoDatos.ExisteInsumo(insumo.NombreInsumo)) // ✅ Verificar duplicados
            {
                return false; 
            }

            return insumoDatos.InsertarInsumo(insumo);
        }

        public List<InsumoConCategoria> ObtenerInsumosConCategoria()
        {
            return insumoDatos.ObtenerInsumosConCategoria(); // ✅ Llamando la lista de insumos
        }

        public bool ActualizarInsumo(Insumo insumo)
        {
            return insumoDatos.ActualizarInsumo(insumo); 
        }

        public bool EliminarInsumo(int idInsumo)
        {
            return insumoDatos.EliminarInsumo(idInsumo); 
        }

       public bool ActualizarStock(int idInsumo, int nuevaCantidad)
        {

            return insumoDatos.ActualizarStock(idInsumo, nuevaCantidad);
        }

        public List<Insumo> ObtenerInsumosPorCategoria(int idCategoria)
        {
            return insumoDatos.ObtenerInsumosPorCategoria(idCategoria);
        }

        public string ObtenerMedidaInsumo(int idInsumo)
        {
            return insumoDatos.ObtenerMedidaInsumo(idInsumo);
        }
    }
}
