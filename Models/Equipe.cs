using System;
using System.Collections.Generic;
using System.IO;
using MVC_E_Players.Interfaces;
namespace MVC_E_Players.Models
{
    public class Equipe : EPlayersBase, IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public const string CAMINHO = "database/equipes";

        public Equipe()
        {
            CriarPastaArquivo(CAMINHO);
        }

        public void Alterar(Equipe e)
        {
            List<string> lines = LerTodasLinhasCSV(CAMINHO);
            lines.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            lines.Add(Preparar(e));
            ReescreverCSV(CAMINHO, lines);
        }

        public void Criar(Equipe e)
        {
            string[] linha = { Preparar(e) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int id)
        {
            List<string> linha = LerTodasLinhasCSV(CAMINHO);
            linha.RemoveAll(x => x.Split(";")[0] == id.ToString());
            ReescreverCSV(CAMINHO, linha);
        }

        public List<Equipe> LerTodas()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe time = new Equipe();
                time.IdEquipe = Int32.Parse(linha[0]);
                time.Nome = linha[1];
                time.Imagem = linha[2];
                equipes.Add(time);
            }
            return equipes;
        }

        public string Preparar(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }
    }
}