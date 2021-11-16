using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model.Models
{
    public partial class ClientPublic
    {
        public string Correo { get; set; }
        public string PrimerNom { get; set; }
        public string SegNom { get; set; }
        public string PrimerApellido { get; set; }
        public string SegApellido { get; set; }
        public double? MaxCalorias { get; set; }
        public DateTime? FechaNace { get; set; }
        public double? Imc { get; set; }
        public string CorreoNutri { get; set; }
    }
}
