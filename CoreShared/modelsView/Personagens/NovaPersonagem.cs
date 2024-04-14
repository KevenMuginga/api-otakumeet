using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShared.modelsView.Personagens
{
    public class NovaPersonagem
    {
        public string Nome { get; set; }
        public IFormFile File{ get; set; }
        public int AnimeId { get; set; }
    }
}
