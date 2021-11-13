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
    [Route("Menu")]
    public class Plan_Menu : Controller
    {
        NutriTECContext Db = new NutriTECContext();
        [HttpGet]
        public ActionResult Get(string PlanName,string menuName)
        {

            try
            {
                var Response = Db.Menus.Where(menu => menu.NombrePlanAlimentacion == PlanName).Where(menu=>menu.Nombre==menuName);
                return Ok(Response.ToList().ElementAt(0));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
        [HttpPost]
        public ActionResult Post([FromBody] PlanEntry entry)
        {
            try
            {
                string PlanName = entry.Nombre_Plan;
                string NutricionistEmail = entry.Correo_Nutricionista;
                MenuEntry menu = entry.Menu;
                var result=Db.PlanAlimentacions.FromSqlInterpolated($"exec spAddMenuToPlan {PlanName},{NutricionistEmail},{menu.Name}").ToList();
                
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
