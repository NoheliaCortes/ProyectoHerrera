using System;
using System.Collections.Generic;
using System.Data;
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
        public DataTable ObtenerProductoPorFiltros(int idLinea, int idSabor, int idMedida, int idPeso)
        {
            ProductoDatos productoDatos = new ProductoDatos();
            return productoDatos.ObtenerProductoPorFiltros(idLinea, idSabor, idMedida, idPeso);
        }


        public DataTable BuscarProductoConDescuento(int idLinea, int idSabor, int idMedida, int idPeso)
        {
            ProductoDatos productoDatos = new ProductoDatos();
            return productoDatos.BuscarProductoConDescuento(idLinea, idSabor, idMedida, idPeso);
        }

        public bool ExisteProducto(int idSabor, int idPeso)
        {
            ProductoDatos productoDatos = new ProductoDatos(); 
            return productoDatos.ExisteProducto(idSabor, idPeso); 
        }

        public List<ProductoConStock> FiltrarProductos(int idLinea, int idSabor, int idPeso, int idMedida)
        {
            ProductoDatos productoDatos = new ProductoDatos(); 
            return productoDatos.FiltrarProductos(idLinea, idSabor, idPeso, idMedida); 
        }

        public bool VerificarStock(int idproducto, int cantidadvendida)
        {
            ProductoDatos productoDatos = new ProductoDatos();
            return productoDatos.VerificarStock(idproducto, cantidadvendida);



        }

    }
}