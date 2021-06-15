using MVC_E_Players.Interfaces;

namespace MVC_E_Players.Models
{
    public class Noticias : EPlayersBase, INoticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
    }
}