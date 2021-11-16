using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriTEC_rest.SQL_Model.Agrupaciones
{
    public class MenuEntry
    {
        public string Name { get; set; }
        public string[] productos { get; set; }
        public List<receta_strings> recetas { get; set; }
    }
}
