using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model
{
    public partial class RecetaProducto
    {
        public string NombreReceta { get; set; }
        public string CorreoCreador { get; set; }
        public string CodigoBarras { get; set; }
        public int? Cantidad { get; set; }

        public virtual Producto CodigoBarrasNavigation { get; set; }
        public virtual Recetum Recetum { get; set; }
    }
}
