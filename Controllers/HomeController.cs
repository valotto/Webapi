using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;
using MongoDB.Bson;

namespace webapi.Controllers
{
    public class HomeController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }

        // GET: api/<controller>
        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("Listar")]
        public async Task<JsonResult> Get()
        {
            var mongodbService = new mongoDbServices("pizzauds", "mongouds", "mongodb://mongouds:Jw30tpPIPe_-@den1.mongo1.gear.host:27001/?authSource=mongouds");
            var allTodos = await mongodbService.GetAllTodos();       
            return Json(allTodos);
            
        }
    }
}
