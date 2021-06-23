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
        Equipe teste = new Equipe();

        [Route("ListarJogador")]
        public IActionResult Index()
        {
            ViewBag.Jogador = player.LerTodas();
            ViewBag.Equipe = teste.LerTodas();
            return View();
        }

        [Route("CadastrarJogador")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador NovoJogador = new Jogador();
            NovoJogador.Nome = form["NomeJ"];
            NovoJogador.IdJogador = Int32.Parse(form["IdJogador"]);
            NovoJogador.IdEquipe = Int32.Parse(form["EquipeJ"]);
            NovoJogador.Senha = form["Senha"];
            NovoJogador.Email = form["Email"];
            player.Criar(NovoJogador);

            ViewBag.Jogador = player.LerTodas();

            return LocalRedirect("~/Jogador/ListarJogador");
        }

        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            player.Deletar(id);
            ViewBag.Jogador = player.LerTodas();
            return LocalRedirect("~/Jogador/ListarJogador");
        }
    }
}