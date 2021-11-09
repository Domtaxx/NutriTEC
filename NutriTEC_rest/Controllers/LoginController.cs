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
    [Route("Login/Client")]
    public class LoginController : Controller
    {
        NutriTECContext Db = new NutriTECContext();
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var clients = Db.Clientes.ToList();
                return Ok(clients);
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
