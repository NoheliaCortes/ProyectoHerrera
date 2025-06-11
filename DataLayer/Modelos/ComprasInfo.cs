using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Modelos
{
    public class ComprasInfo
    {
        public int IdCompra { get; set; }
        public string Proveedor { get; set; } // ✅ Nombre del proveedor
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<DetalleCompraInfo> Detalles { get; set; } = new List<DetalleCompraInfo>();
    }

    public class DetalleCompraInfo
    {
        public int IdDetalleCompra { get; set; }
        public string Insumo { get; set; } // ✅ Nombre del insumo
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario; // ✅ Calcula el subtotal
    }

}
