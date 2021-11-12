using System;
using System.Collections.Generic;

#nullable disable

namespace NutriTEC_rest.SQL_Model
{
    public partial class MedidaPublic
    {
        public double? Cadera { get; set; }
        public double? PorcentajeMusculo { get; set; }
        public double? PorcentajeGrasa { get; set; }
        public double? Cuello { get; set; }
        public double? Cintura { get; set; }
        public DateTime Fecha { get; set; }
    }
}
