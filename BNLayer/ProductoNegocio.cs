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

        public void AgregarStock(int idProducto, int cantidad)
        {
            ProductoDatos productoDatos = new ProductoDatos();
            productoDatos.ModificarStock(idProducto, cantidad);
        }

        public void EliminarStock(int idProducto, int cantidad)
        {
            ProductoDatos productoDatos = new ProductoDatos();
            productoDatos.ModificarStock(idProducto, -cantidad); 
        }

        public int ObtenerStockActual(int idProducto)
        {
            return productoDatos.ObtenerStockActual(idProducto);
        }

        public void ActualizarProducto(Producto producto)
        {
            ProductoDatos productoDatos = new ProductoDatos();
            productoDatos.ActualizarProducto(producto);
        }

        public Producto ObtenerProductoPorId(int idProducto)
        {
            ProductoDatos productoDatos = new ProductoDatos();
            return productoDatos.ObtenerProductoPorId(idProducto);
        }

        public void EliminarProducto(int idProducto)
        {
            ProductoDatos productoDatos = new ProductoDatos();
            productoDatos.EliminarProducto(idProducto);
        }


    }
}