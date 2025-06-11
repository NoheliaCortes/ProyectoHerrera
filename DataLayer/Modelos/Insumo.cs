using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Modelos
{
    public class Insumo
    {
        public int IdInsumo { get; set; }
        public string NombreInsumo { get; set; }
        public int IdCategoria { get; set; }
        public int IdMedida { get; set; }
    }

}
