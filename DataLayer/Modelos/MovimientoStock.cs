using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Modelos
{
    public class MovimientoStock
    {
        public int IdMovimiento { get; set; }
        public int IdProducto { get; set; }
        public int IdTipoMovimiento { get; set; } 
        public int IdUsuario { get; set; } 
        public int CantidadMovida { get; set; }
        public int StockAnterior { get; set; }
        public int StockPosterior { get; set; }
        public DateTime FechaMovimiento { get; set; }

        public string MotivoMovimiento { get; set; }

    }

}
