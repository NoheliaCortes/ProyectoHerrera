using System.Collections.Generic;
using DataLayer;
using DataLayer.Modelos;  



namespace BNLayer
{
    public class ProveedorNegocio
    {
        private ProveedorDatos proveedorDatos = new ProveedorDatos();

        public List<Proveedor> ObtenerProveedores()
        {
            return proveedorDatos.ObtenerProveedores();
        }

        public Proveedor ObtenerProveedorPorId(int idProveedor)
        {
            return proveedorDatos.ObtenerProveedorPorId(idProveedor);
        }

        public int AgregarProveedor(Proveedor proveedor)
        {
            int nuevoId = proveedorDatos.AgregarProveedor(proveedor);
            proveedor.Id_Proveedor = nuevoId;
            return nuevoId;
        }


        public void ActualizarProveedor(Proveedor proveedor)
        {
            proveedorDatos.ActualizarProveedor(proveedor);
        }

        public void EliminarProveedor(int idProveedor)
        {
            proveedorDatos.EliminarProveedor(idProveedor);
        }
    }
}
