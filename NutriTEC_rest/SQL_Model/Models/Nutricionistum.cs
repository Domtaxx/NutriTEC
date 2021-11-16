using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model.Models
{
    public partial class Nutricionistum
    {
        public Nutricionistum()
        {
            Clientes = new HashSet<Cliente>();
            PlanAlimentacions = new HashSet<PlanAlimentacion>();
        }

        public string Correo { get; set; }
        public string Contra { get; set; }
        public string Codigo { get; set; }
        public string PrimerNom { get; set; }
        public string SegNom { get; set; }
        public string PrimerApellido { get; set; }
        public string SegApellido { get; set; }
        public string NumTarjeta { get; set; }
        public DateTime? FechaNace { get; set; }
        public string TipoCobro { get; set; }
        public string Direccion { get; set; }
        public double? Imc { get; set; }
        public double? Peso { get; set; }
        public string Foto { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<PlanAlimentacion> PlanAlimentacions { get; set; }
    }
}
