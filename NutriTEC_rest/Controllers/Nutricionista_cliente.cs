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
    [Route("Nutricionista/Clientes")]
    public class Nutricionista_cliente : Controller
    {
        NutriTECContext Db = new NutriTECContext();
        [HttpGet]
        public ActionResult Get(string Correo_nutri)
        {
            try
            {
                var res = Db.ClientPublics.FromSqlInterpolated($"exec spGetClientes {Correo_nutri}");
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Route("plan")]
        [HttpGet]
        public ActionResult get(string Correo_cliente)
        {
            try
            {
                ClientePlan temp = Db.ClientePlans.Where(CP=>CP.CorreoCliente == Correo_cliente).Single();
                var res = Db.Menus.Where(M=>M.NombrePlanAlimentacion == temp.NombrePlan).Include(M=>M.MenuProductos).ThenInclude(MP => MP.CodigoBarrasNavigation).Include(M=>M.MenuReceta);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]Cliente_nutricionista correos)
        {
            try
            {
                var res = Db.Clientes.Find(correos.CorreoCliente);
                res.CorreoNutri = correos.CorreoNutricionista;
                Db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("especifico")]
        [HttpGet]
        public ActionResult get2(string Correo_cliente)
        {
            try
            {
                var res = Db.ClientPublics.FromSqlInterpolated($"exec spGetCliente {Correo_cliente}");
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Route("Plan/delete")]
        [HttpDelete]
        public ActionResult Delete(string nombre_plan)
        {
            try
            {
                var a = Db.PlanAlimentacions.Find(nombre_plan);
                Db.PlanAlimentacions.Remove(a);
                Db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
