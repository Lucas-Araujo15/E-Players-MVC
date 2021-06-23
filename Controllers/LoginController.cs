using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_E_Players.Models;

namespace MVC_E_Players.Controllers
{

    [Route("Login")]
    public class LoginController : Controller
    {
        [TempData]
        public string Mensagem { get; set; }

        [TempData]
        public int i { get; set; }




        Jogador jogadorModel = new Jogador();

        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {

            i++;
            
            List<string> jogadoresCSV = jogadorModel.LerTodasLinhasCSV("database/jogador");
            var logado = jogadoresCSV.Find(x => x.Split(";")[3] == form["Senha1"] && x.Split(";")[4] == form["Email1"]);

            if (logado != null)
            {
                HttpContext.Session.SetString("_Username", logado.Split(";")[1]);
                return LocalRedirect("~/");
            }

            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login");
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_Username");
            return LocalRedirect("~/");
        }
    }
}