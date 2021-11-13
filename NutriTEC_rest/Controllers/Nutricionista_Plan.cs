using Microsoft.AspNetCore.Mvc;
using NutriTEC_rest.DB_Context;
using NutriTEC_rest.SQL_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutriTEC_rest.SQL_Model.Agrupaciones;

namespace NutriTEC_rest.Controllers
{
    [ApiController]
    [Route("Plan")]
    public class Nutricionista_Plan : Controller
    {
        NutriTECContext Db = new NutriTECContext();
        [HttpGet]
        public ActionResult Get(string PlanName)
        {
            
            try
            {
                var Response = Db.PlanAlimentacions.Where(plan => plan.Nombre == PlanName);
                return Ok(Response.ToList().ElementAt(0));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
        [HttpPost]
        public ActionResult Post([FromBody]PlanAlimentacion entry)
        {
            try
            {
                string PlanName = entry.Nombre;
   
                string NutricionistEmail = entry.CorreoNutri;
                Db.PlanAlimentacions.FromSqlInterpolated($"exec spAddPlan {PlanName},{NutricionistEmail}");
                var plan = Db.PlanAlimentacions.Where(R => R.Nombre == PlanName).Where(R => R.CorreoNutri == NutricionistEmail).ToList().ElementAt(0);
                return Ok(plan);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        
    }
}
