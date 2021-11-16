using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model.Models
{
    public partial class ReporteCobro
    {
        public string Correo { get; set; }
        public int? Atendidos { get; set; }
        public double? Pago { get; set; }
    }
}
