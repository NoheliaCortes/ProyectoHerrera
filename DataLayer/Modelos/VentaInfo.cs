using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Modelos
{
    public class VentaInfo
    {
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }
        public string Usuario { get; set; }
        public string Cliente { get; set; }
    }

}
