using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Modelos
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<DetalleCompra> Detalles { get; set; } = new List<DetalleCompra>(); // ✅ Lista de detalles de compra
    }
}
