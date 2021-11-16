using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model.Models
{
    public partial class Recetum
    {
        public Recetum()
        {
            ClienteReceta = new HashSet<ClienteRecetum>();
            MenuReceta = new HashSet<MenuRecetum>();
            RecetaProductos = new HashSet<RecetaProducto>();
        }

        public string CorreoAdmin { get; set; }
        public string Nombre { get; set; }
        public string CorreoCreador { get; set; }
        public bool? Aprobado { get; set; }

        public virtual Administrador CorreoAdminNavigation { get; set; }
        public virtual Cliente CorreoCreadorNavigation { get; set; }
        public virtual ICollection<ClienteRecetum> ClienteReceta { get; set; }
        public virtual ICollection<MenuRecetum> MenuReceta { get; set; }
        public virtual ICollection<RecetaProducto> RecetaProductos { get; set; }
    }
}
