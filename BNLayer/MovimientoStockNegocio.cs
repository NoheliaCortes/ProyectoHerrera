using DataLayer.Modelos;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNLayer
{
    public class MovimientoStockNegocio
    {
        public bool RegistrarMovimientoStock(MovimientoStock movimiento)
        {
            MovimientoStockDatos movimientoDatos = new MovimientoStockDatos();
            return movimientoDatos.RegistrarMovimientoStock(movimiento);
        }
        public List<MovimientoStockInfo> ObtenerMovimientosStock()
        {
            MovimientoStockDatos movimientoDatos = new MovimientoStockDatos();
            return movimientoDatos.ObtenerMovimientosStock();
        }

    }
}
