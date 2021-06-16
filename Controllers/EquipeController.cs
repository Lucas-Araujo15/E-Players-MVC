using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_E_Players.Models;

namespace MVC_E_Players.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Equipe = equipeModel.LerTodas();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome = form["Nome"];
            novaEquipe.Imagem = form["Imagem"];

            equipeModel.Criar(novaEquipe);

            ViewBag.Equipes = equipeModel.LerTodas();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}