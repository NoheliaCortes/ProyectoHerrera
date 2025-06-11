using DataLayer.Modelos;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNLayer
{
    public class CategoriaNegocio
    {
        private CategoriaDatos categoriaDatos = new CategoriaDatos(); // ✅ Instancia de `CategoriaDatos`

        public bool InsertarCategoria(CategoriaInsumo categoria)
        {
            return categoriaDatos.InsertarCategoria(categoria); // ✅ Llamando el método desde la capa de negocio
        }

        public List<CategoriaInsumo> ObtenerCategorias()
        {
            return categoriaDatos.ObtenerCategorias(); // ✅ Llamando la lista de categorías
        }

        public bool ActualizarCategoria(CategoriaInsumo categoria)
        {
            return categoriaDatos.ActualizarCategoria(categoria); // ✅ Llamando actualización desde negocio
        }

        public bool EliminarCategoria(int idCategoria)
        {
            return categoriaDatos.EliminarCategoria(idCategoria); // ✅ Llamando eliminación desde negocio
        }



    }
}
