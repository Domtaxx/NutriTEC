using Microsoft.AspNetCore.Mvc;
using NutriTEC_rest.DB_Context;
using NutriTEC_rest.SQL_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriTEC_rest.Controllers
{
    public class Admin : Controller
    {
        NutriTECContext Db = new NutriTECContext();
        [Route("Recetas")]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var res = Db.RecetaPublics.FromSqlInterpolated($"GetRecetaSum");
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Recetas")]
        [HttpPut]
        public ActionResult Put([FromBody] Recetum receta)
        {
            try
            {
                Db.Receta.Update(receta);
                Db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Productos")]
        [HttpGet]
        public ActionResult Get2()
        {
            try
            {
                var res = Db.Productos.Where(R => R.Estado == "Inhabilitado" || R.Estado == null);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Productos")]
        [HttpPut]
        public ActionResult Put([FromBody] Producto prod)
        {
            try
            {
                Db.Productos.Update(prod);
                Db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("ReporteCobro")]
        [HttpGet]
        public ActionResult Get23(string tipo)
        {
            try
            {
                var res = Db.ReporteCobros.FromSqlInterpolated($"exec GetPaymentAmount {tipo}");
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
