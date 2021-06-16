using System.Collections.Generic;
using MVC_E_Players.Models;

namespace MVC_E_Players.Interfaces
{
    public interface IJogador
    {
        void Criar(Jogador e);

        List<Jogador> LerTodas();

        void Alterar(Jogador e);

        void Deletar(int id);
    }
}