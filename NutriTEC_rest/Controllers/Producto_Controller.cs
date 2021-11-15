using Microsoft.AspNetCore.Mvc;
using NutriTEC_rest.DB_Context;
using NutriTEC_rest.SQL_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutriTEC_rest.SQL_Model.Models;

namespace NutriTEC_rest.Controllers
{
    [ApiController]
    [Route("Producto/buscar")]
    public class Producto_Controller:Controller
    {
        NutriTECContext Db = new NutriTECContext();

        [HttpGet]
        public ActionResult Get(string Codigo,string desc= "aasdasasdfasd1234jadfvasd1234nadbfh1")
        {
            try
            {
                var products = Db.Productos.FromSqlInterpolated($"exec spGetProduct {Codigo},{desc}").ToList();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Producto prod)
        {
            try
            {
                Db.Productos.Add(prod);
                Db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Todos")]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var products = Db.Productos.ToList();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
