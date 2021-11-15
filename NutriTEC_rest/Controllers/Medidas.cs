using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutriTEC_rest.SQL_Model.Models;
using NutriTEC_rest.DB_Context;

namespace NutriTEC_rest.Controllers
{

    [ApiController]
    [Route("Cliente/Medidas")]
    public class Medidas : Controller
    {
        NutriTECContext Db = new NutriTECContext();
        [HttpPost]
        public ActionResult Post([FromBody] RegistroMedida RM)
        {
            try
            {
                Db.RegistroMedidas.Add(RM);
                Db.SaveChanges();
                return Ok(RM);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public ActionResult Get (string correo,DateTime fecha)
        {
            try
            {
                var medidas = Db.RegistroMedidas.Where(M => M.CorreoCliente == correo && M.Fecha == fecha);
                return Ok(medidas.ToList().ElementAt(0));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Todas")]
        [HttpGet]
        public ActionResult Get(string correo)
        {
            try
            {
                var medidas = Db.RegistroMedidas.Where(M => M.CorreoCliente == correo);
                return Ok(medidas.ToList().ElementAt(0));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}


