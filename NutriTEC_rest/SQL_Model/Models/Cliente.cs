using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClientePlans = new HashSet<ClientePlan>();
            ClienteProductos = new HashSet<ClienteProducto>();
            ClienteReceta = new HashSet<ClienteRecetum>();
            Receta = new HashSet<Recetum>();
            RegistroMedida = new HashSet<RegistroMedida>();
        }

        public string Correo { get; set; }
        public string Contra { get; set; }
        public string Direccion { get; set; }
        public string PrimerNom { get; set; }
        public string SegNom { get; set; }
        public string PrimerApellido { get; set; }
        public string SegApellido { get; set; }
        public double? MaxCalorias { get; set; }
        public DateTime? FechaNace { get; set; }
        public double? Peso { get; set; }
        public double? Imc { get; set; }
        public string CorreoNutri { get; set; }

        public virtual Nutricionistum CorreoNutriNavigation { get; set; }
        public virtual ICollection<ClientePlan> ClientePlans { get; set; }
        public virtual ICollection<ClienteProducto> ClienteProductos { get; set; }
        public virtual ICollection<ClienteRecetum> ClienteReceta { get; set; }
        public virtual ICollection<Recetum> Receta { get; set; }
        public virtual ICollection<RegistroMedida> RegistroMedida { get; set; }
    }
}
