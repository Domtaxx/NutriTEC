using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model.Models
{
    public partial class Administrador
    {
        public Administrador()
        {
            Productos = new HashSet<Producto>();
            Receta = new HashSet<Recetum>();
        }

        public string Correo { get; set; }
        public string Contra { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Recetum> Receta { get; set; }
    }
}
