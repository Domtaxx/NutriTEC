using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model.Models
{
    public partial class MenuProducto
    {
        public string NombrePlanAlimentacion { get; set; }
        public string NombreMenu { get; set; }
        public string CodigoBarras { get; set; }

        public virtual Producto CodigoBarrasNavigation { get; set; }
        public virtual Menu Nombre { get; set; }
    }
}
