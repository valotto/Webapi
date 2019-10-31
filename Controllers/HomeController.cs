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
            var mongodbService = new mongoDbServices("test", "Dados", "mongodb+srv://admin:010203@clustervalotto-c9rs6.mongodb.net/test");
            var allTodos = await mongodbService.GetAllTodos();       
            return Json(allTodos);
            
        }
    }
}
