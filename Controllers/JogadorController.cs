using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_E_Players.Models;

namespace MVC_E_Players.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador player = new Jogador();

        [Route("ListarJogador")]
        public IActionResult Index()
        {
            ViewBag.Jogador = player.LerTodas();
            return View();
        }

        [Route("CadastrarJogador")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador NovoJogador = new Jogador();
            NovoJogador.Nome = form["NomeJ"];
            NovoJogador.IdJogador = Int32.Parse(form["IdJogador"]);
            NovoJogador.IdEquipe = Int32.Parse(form["EquipeJ"]);
            player.Criar(NovoJogador);

            ViewBag.Jogador = player.LerTodas();

            return LocalRedirect("~/Jogador/ListarJogador");
        }
    }
}