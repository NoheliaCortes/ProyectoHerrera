using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;


namespace BNLayer
{
    public class ProductoNegocio
    {
        private ProductoDatos productoDatos = new ProductoDatos();

        public List<ProductoConStock> ObtenerProductosConStock()
        {
            return productoDatos.ObtenerProductosConStock();
        }

        public void RegistrarProducto(Producto producto)
        {
            ProductoDatos productoDatos = new ProductoDatos();
            productoDatos.InsertarProducto(producto);
        }




    }
}