using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model
{
    public partial class ClienteProducto
    {
        public string CodigoBarras { get; set; }
        public string CorreoCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Tiempo { get; set; }

        public virtual Producto CodigoBarrasNavigation { get; set; }
        public virtual Cliente CorreoClienteNavigation { get; set; }
    }
}
