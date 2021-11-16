using Microsoft.AspNetCore.Mvc;
using NutriTEC_rest.DB_Context;
using NutriTEC_rest.SQL_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriTEC_rest.Controllers
{
    [ApiController]
    [Route("Crear")]
    public class Creacion_Usuario_Controller : Controller
    {
        NutriTECContext Db = new NutriTECContext();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cli"></param>
        /// <returns></returns>   
        [Route("Cliente")]
        [HttpPost]
        public ActionResult Post([FromBody] Cliente cli)
        {
            try
            {
                Db.Clientes.Add(cli);
                Db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("Cliente")]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(Db.Clientes.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nutri"></param>
        /// <returns></returns>
        [Route("Nutricionista")]
        [HttpPost]
        public ActionResult Post([FromBody] Nutricionistum nutri)
        {
            try
            {
                Db.Nutricionista.Add(nutri);
                Db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("Nutricionista")]
        [HttpGet]
        public ActionResult get()
        {
            try
            {
                return Ok(Db.Nutricionista.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
