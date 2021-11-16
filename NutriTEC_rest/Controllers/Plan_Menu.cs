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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PlanName"></param>
        /// <param name="menuName"></param>
        /// <returns></returns>
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
        [Route("productos")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] PlanEntry entry)
        {
            try
            {
                string PlanName = entry.Nombre_Plan;
                string NutricionistEmail = entry.Correo_Nutricionista;
                MenuEntry menu = entry.Menu;
                var result=Db.Menus.FromSqlInterpolated($"exec spAddMenuToPlan {PlanName},{menu.Name},{NutricionistEmail}").ToList();
                foreach(var product in menu.productos)
                {
                    try
                    {
                        var result1=Db.ProductoPublics.FromSqlInterpolated($"exec spAddProductToMenu {PlanName},{menu.Name},{product},{NutricionistEmail}").ToList();
                    }
                    catch (Exception e) { }

                    
                }
                //var plan = Db.PlanAlimentacions.Where(R => R.Nombre == PlanName).Where(R => R.CorreoNutri == NutricionistEmail).ToList().ElementAt(0);
                return Ok(null);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("recetas")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult post([FromBody] PlanEntry entry)
        {
            try
            {
                string PlanName = entry.Nombre_Plan;
                string NutricionistEmail = entry.Correo_Nutricionista;
                var result = Db.Menus.FromSqlInterpolated($"exec spAddMenuToPlan {PlanName},{entry.Menu},{NutricionistEmail}").ToList();
                foreach (receta_strings receta in entry.Menu.recetas)
                {
                    try
                    {
                        var result1 = Db.ProductoPublics.FromSqlInterpolated($"exec spAddRecetaToMenu {PlanName},{entry.Menu.Name},{receta.Nombre},{receta.Creador},{NutricionistEmail}").ToList();
                    }
                    catch (Exception e) {
                        return BadRequest(e.Message);
                    }
                }
                //var plan = Db.PlanAlimentacions.Where(R => R.Nombre == PlanName).Where(R => R.CorreoNutri == NutricionistEmail).ToList().ElementAt(0);
                return Ok(null);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
