using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriTEC_rest.SQL_Model.Agrupaciones
{
    public class Receta_Productos
    {
        public string Nombre { get; set; }
        public string CorreoCreador { get; set; }
        public List<string> productos { get; set;}
    }
}
