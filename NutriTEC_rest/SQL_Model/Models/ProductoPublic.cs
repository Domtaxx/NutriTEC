using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model.Models
{
    public partial class ProductoPublic
    {
        public string CodigoBarras { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public double? Sodio { get; set; }
        public double? Energia { get; set; }
        public double? Carbohidratos { get; set; }
        public double? Tamano { get; set; }
        public double? Vitaminas { get; set; }
        public double? Hierro { get; set; }
        public double? Calcio { get; set; }
        public double? Proteina { get; set; }
    }
}
