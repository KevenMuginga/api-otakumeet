using CoreShared.modelsView.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShared.modelsView.posts
{
    public class PostView
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string? ImgUrl { get; set; }
        public int Estrelas { get; set; }
        public PersonagemView Personagem { get; set; }
    }
}
