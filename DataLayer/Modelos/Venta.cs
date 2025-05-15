using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Modelos
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdCliente { get; set; } 
        public List<DetalleVenta> Detalles { get; set; }
        public Venta()
        {
            Detalles = new List<DetalleVenta>();

        }


    }
}
