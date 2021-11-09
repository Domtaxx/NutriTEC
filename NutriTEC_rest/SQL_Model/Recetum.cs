using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model
{
    public partial class Recetum
    {
        public Recetum()
        {
            ClienteReceta = new HashSet<ClienteRecetum>();
            MenuReceta = new HashSet<MenuRecetum>();
        }

        public string CorreoAdmin { get; set; }
        public string Nombre { get; set; }

        public virtual Administrador CorreoAdminNavigation { get; set; }
        public virtual ICollection<ClienteRecetum> ClienteReceta { get; set; }
        public virtual ICollection<MenuRecetum> MenuReceta { get; set; }
    }
}
