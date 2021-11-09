using Microsoft.AspNetCore.Mvc;
using NutriTEC_rest.DB_Context;
using NutriTEC_rest.SQL_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriTEC_rest.Controllers
{
    [ApiController]
    [Route("Client/Product")]
    public class Client_Product:Controller
    {
        NutriTECContext Db = new NutriTECContext();
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var products = Db.Productos.FromSqlRaw("exec spGetAllProducts").ToList();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
