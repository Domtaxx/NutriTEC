using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model
{
    public partial class NutricionistaPublic
    {
        public string Correo { get; set; }
        public string Codigo { get; set; }
        public string PrimerNom { get; set; }
        public string SegNom { get; set; }
        public string PrimerApellido { get; set; }
        public string SegApellido { get; set; }
        public DateTime? FechaNace { get; set; }
        public string Foto { get; set; }
    }
}
