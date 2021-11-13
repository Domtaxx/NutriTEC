using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model.Models
{
    public partial class ClienteRecetum
    {
        public string NombreReceta { get; set; }
        public string CorreoCliente { get; set; }
        public string CorreoCreador { get; set; }
        public DateTime Fecha { get; set; }
        public string Tiempo { get; set; }

        public virtual Cliente CorreoClienteNavigation { get; set; }
        public virtual Recetum Recetum { get; set; }
    }
}
