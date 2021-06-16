using System;
using System.Collections.Generic;
using System.IO;
using MVC_E_Players.Interfaces;

namespace MVC_E_Players.Models
{
    public class Jogador : EPlayersBase, IJogador
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public int IdEquipe { get; set; }
        public const string CAMINHO = "database/jogador";

        public Jogador()
        {
            CriarPastaArquivo(CAMINHO);
        }
        public void Alterar(Jogador e)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[2] == e.IdJogador.ToString());
            linhas.Add(Preparar(e));
            ReescreverCSV(CAMINHO, linhas);
        }

        public void Criar(Jogador e)
        {
            string[] linha = { Preparar(e) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int id)
        {
            List<string> JogadorDelete = LerTodasLinhasCSV(CAMINHO);
            JogadorDelete.RemoveAll(x => x.Split(";")[2] == id.ToString());
            ReescreverCSV(CAMINHO, JogadorDelete);
        }

        public List<Jogador> LerTodas()
        {
            List<Jogador> jogadores = new List<Jogador>();
            Jogador jogador = new Jogador();
            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                jogador.IdEquipe = Int32.Parse(linha[0]);
                jogador.Nome = linha[1];
                jogador.IdJogador = Int32.Parse(linha[2]);

                jogadores.Add(jogador);
            }
            return jogadores;
        }

        public string Preparar(Jogador e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.IdJogador}";
        }
    }
}