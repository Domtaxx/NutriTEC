using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [Route("Nutricionista/Clientes")]
    public class Nutricionista_cliente : Controller
    {
        NutriTECContext Db = new NutriTECContext();
        [HttpGet]
        public ActionResult Get(string Correo_nutri)
        {
            try
            {
                var res = Db.ClientPublics.FromSqlInterpolated($"exec spGetClientes {Correo_nutri}");
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpPost]
        public ActionResult Post([FromBody]Cliente_nutricionista correos)
        {
            try
            {
                var res = Db.Clientes.Find(correos.CorreoCliente);
                res.CorreoNutri = correos.CorreoNutricionista;
                Db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Route("especifico")]
        [HttpGet]
        public ActionResult get(string Correo_cliente)
        {
            try
            {
                var res = Db.ClientPublics.FromSqlInterpolated($"exec spGetCliente {Correo_cliente}");
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
