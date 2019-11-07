using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreDocker.Models;
using CoreDocker.Services;


namespace CoreDocker.Controllers
{
    public class HomeController : Controller
    {    
     
        TodoModel sm = new TodoModel();

        public IActionResult Index(string Personalizacao, string Tamanho, 
            string Sabor, decimal Valor_total, string Tempo_preparo, string Mesa_register)
        {
            
             //ViewBag.noty = "hidden"; 

            if (Valor_total != 0 && Tempo_preparo != null)
            {                 
                             
               sm.Personalizacao = Personalizacao;
               sm.Tamanho = Tamanho;
               sm.Sabor = Sabor;
               sm.Valor_total = Valor_total;
               sm.Tempo_preparo = Tempo_preparo;
               sm.Mesa_register = Mesa_register;


                var mongodbService = new MongodbServices("mongouds", "pizzauds", "mongodb://mongouds:Jw30tpPIPe_-@den1.mongo1.gear.host:27001/?authSource=mongouds");
                mongodbService.InsertTodo(sm);
                ModelState.Clear(); //lIMPAR O FORMULARIO. 

                 
                Response.Redirect(Url.Action("Viewpedido", "Home"));
            }
            
            return View();
        }

        // GET: api/<controller>
        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("Listar")]
        public async Task<JsonResult> Get()
        {
            var mongodbService = new MongodbServices("mongouds", "pizzauds", "mongodb://mongouds:Jw30tpPIPe_-@den1.mongo1.gear.host:27001/?authSource=mongouds");
            var allTodos = await mongodbService.GetAllTodos();
            
            return Json(allTodos);

        }

        public IActionResult Viewpedido()
        {

         ViewBag.noty = "visible";
         ViewBag.detalhes = "Pedido Realizado com sucesso! ";
         return View();

        }



    }//End class
}
