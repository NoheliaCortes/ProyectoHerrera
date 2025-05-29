using DataLayer;
using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BNLayer
{
    public class VentaNegocio
    {
        private VentaDatos ventaDatos = new VentaDatos();



        public void ProcesarVenta(int idCliente, int idUsuario,  decimal total, List<DetalleVenta> detallesVenta)
        {
            int idVenta = ventaDatos.RegistrarVenta(total, idCliente,idUsuario);

            foreach (DetalleVenta detalle in detallesVenta)
            {
                detalle.IdProducto = ventaDatos.ObtenerIdProducto(detalle.NombreProducto);

                
                ventaDatos.RegistrarDetalleVenta(idVenta, detalle.IdProducto, detalle.Cantidad, detalle.Subtotal);

         
                ventaDatos.DescontarStock(detalle.IdProducto, detalle.Cantidad);
            }
        }


        public int ObtenerIdProducto(string nombreProducto)
        {
            return ventaDatos.ObtenerIdProducto(nombreProducto); 
        }





    }
}
