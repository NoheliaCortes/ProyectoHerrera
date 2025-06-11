using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Modelos
{
    public class InsumoConCategoria
    {
        public int IdInsumo { get; set; }
        public string NombreInsumo { get; set; }
        public string Categoria { get; set; }
        public string Medida { get; set; }
        
        public int Stock { get; set; }
    }
}
