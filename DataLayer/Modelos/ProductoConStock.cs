using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProductoConStock
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal CostoProduccion { get; set; }
        public decimal PrecioProducto { get; set; }
        public int Cantidad { get; set; } // Este dato proviene de la tabla StockActual
    }
}
