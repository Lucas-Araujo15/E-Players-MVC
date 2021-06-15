using System.Collections.Generic;
using MVC_E_Players.Models;

namespace MVC_E_Players.Interfaces
{
    public interface IEquipe
    {
        void Criar(Equipe e);

        List<Equipe> LerTodas();

        void Alterar(Equipe e);

        void Deletar(int id);
    }
}