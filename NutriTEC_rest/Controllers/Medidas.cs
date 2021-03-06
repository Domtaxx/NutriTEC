using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutriTEC_rest.SQL_Model.Models;
using NutriTEC_rest.DB_Context;
using Microsoft.EntityFrameworkCore;

namespace NutriTEC_rest.Controllers
{

    [ApiController]
    [Route("Cliente/Medidas")]
    public class Medidas : Controller
    {
        NutriTECContext Db = new NutriTECContext();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RM"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        [Route("Todas")]
        [HttpGet]
        public ActionResult Get(string correo)
        {
            try
            {
                var medidas = Db.RegistroMedidas.Where(M => M.CorreoCliente == correo);
                return Ok(medidas.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        [Route("Reciente")]
        [HttpGet]
        public ActionResult Get2(string correo)
        {
            try
            {
                var medidas = Db.RegistroMedidas.FromSqlInterpolated($"exec spGetMedidasReciente {correo}");
                return Ok(medidas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="FechaI"></param>
        /// <param name="FechaF"></param>
        /// <returns></returns>
        [Route("Periodo")]
        [HttpGet]
        public ActionResult Get(string correo,DateTime FechaI, DateTime FechaF)
        {
            try
            {
                var medidas = Db.RegistroMedidas.FromSqlInterpolated($"exec spGetMedidaPeriodo {correo},{FechaI},{FechaF}");
                return Ok(medidas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}


