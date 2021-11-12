using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model
{
    public partial class MenuRecetum
    {
        public string NombrePlanAlimentacion { get; set; }
        public string NombreMenu { get; set; }
        public string NombreReceta { get; set; }
        public string CorreoCreador { get; set; }

        public virtual Menu Nombre { get; set; }
        public virtual Recetum Recetum { get; set; }
    }
}
