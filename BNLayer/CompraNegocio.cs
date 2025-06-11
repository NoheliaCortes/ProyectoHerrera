using DataLayer.Modelos;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNLayer
{
    public class CompraNegocio
    {
        private CompraDatos compraDatos = new CompraDatos(); // ✅ Instancia de la capa de datos

        public bool RegistrarCompra(Compra compra)
        {
            return compraDatos.RegistrarCompra(compra); // ✅ Registra la compra en la base de datos
        }

        public List<Compra> ObtenerCompras()
        {
            return compraDatos.ObtenerCompras(); // ✅ Obtiene todas las compras registradas
        }

        public List<DetalleCompra> ObtenerDetallesCompra(int idCompra)
        {
            return compraDatos.ObtenerDetallesCompra(idCompra); // ✅ Obtiene los detalles de una compra específica
        }

        

        public List<ComprasInfo> ObtenerHistorialCompras()
        {
            return compraDatos.ObtenerHistorialCompras();
        }



    }
}
