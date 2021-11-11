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
    [Route("Login/Client")]
    public class Login_Cliente : Controller
    {
        NutriTECContext Db = new NutriTECContext();
        [HttpGet]
        public ActionResult Get(string Correo, string Contra)
        {
            try
            {
                var client = Db.ClientPublics.FromSqlInterpolated($"exec spLoginClient {Correo},{Contra}");
                return Ok(client);
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
