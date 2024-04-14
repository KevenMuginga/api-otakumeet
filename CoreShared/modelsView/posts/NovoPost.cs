using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShared.modelsView.posts
{
    public class NovoPost
    {
        public string Descricao { get; set; }
        public IFormFile? File { get; set; }
        public int PersonagemID { get; set; }
    }
}
