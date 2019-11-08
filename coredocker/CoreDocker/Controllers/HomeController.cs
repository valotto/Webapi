using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CoreDocker.Models;
using CoreDocker.Services;


namespace CoreDocker.Controllers
{
    public class HomeController : Controller
    {

        TodoModel sm = new TodoModel();
        private readonly MongodbServices _Mdbs;

        public HomeController(MongodbServices Mdbs) { _Mdbs = Mdbs;  }

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

                //Insert
                try  { _Mdbs.Create(sm);}
                catch{ ViewBag.erro = "Tente novamente em poucos minutos.";}
                
                ModelState.Clear(); //lIMPAR O FORMULARIO. 
                
                Response.Redirect(Url.Action("Viewpedido", "Home"));
            }
            
            return View();
        }



        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("Listar")]
        public ActionResult<List<TodoModel>> Get() => _Mdbs.Get();


        public IActionResult Viewpedido()
        {
         ViewBag.noty = "visible";
         ViewBag.detalhes = "Pedido Realizado com sucesso! ";
         return View();

        }

    }//End class
}
