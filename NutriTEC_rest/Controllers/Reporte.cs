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
    [Route("Reportes")]
    public class Reporte : Controller
    {
        NutriTECContext Db = new NutriTECContext();
        [Route("Productos")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CP"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] ClienteProducto CP)
        {
            try
            {
                Db.ClienteProductos.Add(CP);
                Db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Productos")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Correo_cliente"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get(string Correo_cliente)
        {
            try
            {
                var res = Db.ClienteProductoPublics.FromSqlInterpolated($"exec spGetProduct_report {Correo_cliente}");
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Productos/PeriodoTiempo")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Correo_cliente"></param>
        /// <param name="FechaI"></param>
        /// <param name="FechaF"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult get(string Correo_cliente, DateTime FechaI, DateTime FechaF)
        {
            try
            {
                var res = Db.ClienteProductoPublics.FromSqlInterpolated($"exec spGetReportProductosPeriodo {Correo_cliente},{FechaI},{FechaF}");
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CR"></param>
        /// <returns></returns>
        [Route("Recetas")]
        [HttpPost]
        public ActionResult Post([FromBody] ClienteRecetum CR)
        {
            try
            {
                Db.ClienteReceta.Add(CR);
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
        /// <param name="Correo_cliente"></param>
        /// <returns></returns>
        [Route("Recetas")]
        [HttpGet]
        public ActionResult get(string Correo_cliente)
        {
            try
            {
                var res = Db.RecetaPublics.FromSqlInterpolated($"exec spGetReceta_report {Correo_cliente}");
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Correo_cliente"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [Route("Recetas/fecha")]
        [HttpGet]
        public ActionResult get(string Correo_cliente,DateTime fecha)
        {
            try
            {
                var res = Db.RecetaPublics.FromSqlInterpolated($"exec spGetReceta_report {Correo_cliente}").Where(W=> W.Fecha == fecha);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Correo_cliente"></param>
        /// <param name="FechaI"></param>
        /// <param name="FechaF"></param>
        /// <returns></returns>
        [Route("Recetas/PeriodoTiempo")]
        [HttpGet]
        public ActionResult get2(string Correo_cliente, DateTime FechaI, DateTime FechaF)
        {
            try
            {
                var res = Db.RecetaPublics.FromSqlInterpolated($"exec spGetReportRecetasPeriodo {Correo_cliente},{FechaI},{FechaF}");
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
    }
}
