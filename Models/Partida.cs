using System;
using MVC_E_Players.Interfaces;

namespace MVC_E_Players.Models
{
    public class Partida : EPlayersBase, IPartida
    {
        public int IdPartida { get; set; }
        public int IdJogador1 { get; set; }
        public int IdJogador2 { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioTermino { get; set; }
    }
}