using CoreShared.modelsView.Animes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShared.modelsView.Personagens
{
    public class PersonagemView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? ImgUrl { get; set; }
        public AnimeView Anime { get; set; }
    }
}
