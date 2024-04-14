using CoreShared.modelsView.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShared.modelsView.Animes
{
    public class AnimeView
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string? ImgUrl { get; set; }
        public ICollection<PersonagemView> Personagens { get; set; }
    }
}
