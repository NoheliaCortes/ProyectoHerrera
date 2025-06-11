using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Modelos
{
    public class MovimientoStockInfo
    {
        public int IdMovimiento { get; set; }
        public string Producto { get; set; } 
        public string TipoMovimiento { get; set; } 
        public string Usuario { get; set; } 
        public int CantidadMovida { get; set; }
        public int StockAnterior { get; set; }
        public int StockPosterior { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string MotivoMovimiento { get; set; }
    }

}
