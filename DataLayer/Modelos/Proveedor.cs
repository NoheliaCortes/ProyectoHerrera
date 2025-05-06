using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Modelos
{
    public class Proveedor
    {
        public int Id_Proveedor { get; set; }   
        public string nombre { get; set; }
        public string telefono { get; set; }

        public Proveedor() { }

        public Proveedor(int id_Proveedor, string nombre, string telefono)
        {
            Id_Proveedor = id_Proveedor;
            this.nombre = nombre;
            this.telefono = telefono;
        }
    }

}
