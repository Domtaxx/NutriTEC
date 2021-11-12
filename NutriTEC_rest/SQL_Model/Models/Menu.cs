using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model
{
    public partial class Menu
    {
        public Menu()
        {
            MenuProductos = new HashSet<MenuProducto>();
            MenuReceta = new HashSet<MenuRecetum>();
        }

        public string NombrePlanAlimentacion { get; set; }
        public string Nombre { get; set; }

        public virtual PlanAlimentacion NombrePlanAlimentacionNavigation { get; set; }
        public virtual ICollection<MenuProducto> MenuProductos { get; set; }
        public virtual ICollection<MenuRecetum> MenuReceta { get; set; }
    }
}
