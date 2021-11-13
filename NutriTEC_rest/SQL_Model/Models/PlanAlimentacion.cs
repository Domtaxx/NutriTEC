using System;
using System.Collections.Generic;

#nullable disable
namespace NutriTEC_rest.SQL_Model.Models
{
    public partial class PlanAlimentacion
    {
        public PlanAlimentacion()
        {
            ClientePlans = new HashSet<ClientePlan>();
            Menus = new HashSet<Menu>();
        }

        public string Nombre { get; set; }
        public string CorreoNutri { get; set; }

        public virtual Nutricionistum CorreoNutriNavigation { get; set; }
        public virtual ICollection<ClientePlan> ClientePlans { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
