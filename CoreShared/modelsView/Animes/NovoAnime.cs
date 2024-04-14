using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShared.modelsView.Animes
{
    public class NovoAnime
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public IFormFile? File { get; set; }
    }
}
