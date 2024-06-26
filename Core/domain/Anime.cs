﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.domain
{
    public class Anime
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string? ImgUrl { get; set; }
        public Estado Estado { get; set; }
        public ICollection<Personagem> Personagens { get; set; }
    }
}
