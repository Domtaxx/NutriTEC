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
    [ApiController]
    [Route("Login/Nutricionista")]
    public class Login_Nutricionista : Controller
    {
        NutriTECContext Db = new NutriTECContext();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Correo"></param>
        /// <param name="Contra"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get(string Correo,string Contra)
        {
            try
            {
                var res = Db.NutricionistaPublics.FromSqlInterpolated($"exec spLoginNutri {Correo},{Contra};");
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
