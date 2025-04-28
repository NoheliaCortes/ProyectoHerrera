using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   
        public class Producto
        {
            public int IdProducto { get; set; } 
            public string NombreProducto { get; set; }
            public decimal PrecioProducto { get; set; }
            public decimal DescuentoProducto { get; set; }
            public decimal CostoProduccion { get; set; }

            public int? IdLinea { get; set; }
            public int? IdSabor { get; set; }
            public int? IdPeso { get; set; }
            public int? IdMedida { get; set; }
            public int? IdEnvase { get; set; }
            public int CantidadMinimaDescuento { get; set; }

    }
    






}
