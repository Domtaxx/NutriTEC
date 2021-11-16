using NutriTEC_rest.SQL_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriTEC_rest.SQL_Model.Agrupaciones
{
    public class receta_producto_listas
    {
        public List<ClienteRecetum> recetas { get; set; }
        public List<ClienteProducto> productos { get; set; }
    }
}
