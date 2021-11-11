using Microsoft.AspNetCore.Mvc;
using NutriTEC_rest.DB_Context;
using NutriTEC_rest.SQL_Model.Agrupaciones;
using NutriTEC_rest.SQL_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriTEC_rest.Controllers
{
    [ApiController]
    [Route("Reportes")]
    public class Reporte : Controller
    {
        NutriTECContext Db = new NutriTECContext();
        [Route("Productos")]
        [HttpPost]
        public ActionResult Post([FromBody] ClienteProducto CP)
        {
            try
            {
                Db.ClienteProductos.Add(CP);
                Db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Recetas")]
        [HttpPost]
        public ActionResult Post([FromBody] ClienteRecetum CR)
        {
            try
            {
                Db.ClienteReceta.Add(CR);
                Db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
