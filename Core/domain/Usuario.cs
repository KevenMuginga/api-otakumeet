using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int PersonagemId { get; set; }
        public Personagem Personagem { get; set; }
        public Estado Estado { get; set; }
    }
}
