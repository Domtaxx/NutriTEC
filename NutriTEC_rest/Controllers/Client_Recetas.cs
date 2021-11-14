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
    [Route("Receta/Crear")]
    public class Client_Recetas : Controller
    {
        NutriTECContext Db = new NutriTECContext();
        [HttpPost]
        public ActionResult Post([FromBody]Receta_Productos info)
        {
            try
            {
                Recetum receta = new();
                receta.CorreoAdmin = null;
                receta.Aprobado = false;
                receta.CorreoCreador = info.CorreoCreador;
                receta.Nombre = info.Nombre;
                List<RecetaProducto> productos = new();
                foreach(string s in info.productos)
                {
                    if (productos.Exists(e => e.CodigoBarras == s)){
                        productos.Find(e => e.CodigoBarras == s).Cantidad += 1;
                    }
                    else
                    {
                        Producto temp = Db.Productos.Find(s);
                        RecetaProducto RP = new();
                        RP.CodigoBarras = temp.CodigoBarras;
                        RP.CorreoCreador = info.CorreoCreador;
                        RP.NombreReceta = info.Nombre;
                        RP.Cantidad = 1;
                        productos.Add(RP);
                    }
                }
                Db.Receta.Add(receta);
                foreach(RecetaProducto RP in productos)
                {
                    Db.RecetaProductos.Add(RP);
                }
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
