using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model
{
    public partial class ClientePlan
    {
        public string NombrePlan { get; set; }
        public string CorreoCliente { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Final { get; set; }

        public virtual Cliente CorreoClienteNavigation { get; set; }
        public virtual PlanAlimentacion NombrePlanNavigation { get; set; }
    }
}
