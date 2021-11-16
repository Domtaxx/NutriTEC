using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model.Models
{
    public partial class MedidaPublic
    {
        public double? Cadera { get; set; }
        public double? PorcentajeMusculo { get; set; }
        public double? PorcentajeGrasa { get; set; }
        public double? Cuello { get; set; }
        public double? Cintura { get; set; }
        public DateTime Fecha { get; set; }
        public double? Peso { get; set; }
        public double? Imc { get; set; }
    }
}
