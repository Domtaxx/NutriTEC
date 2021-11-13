using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriTEC_rest.SQL_Model.Agrupaciones
{
    public class PlanEntry
    {
        public String Correo_Nutricionista { get; set; }
        public String Nombre_Plan{get; set;}
        public MenuEntry Menu { get; set; }
    }
}
