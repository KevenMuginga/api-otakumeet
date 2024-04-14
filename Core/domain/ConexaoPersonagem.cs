using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.domain
{
    public class ConexaoPersonagem
    {
        public int Id { get; set; }
        public int PersonagemId { get; set; }
        public Personagem Personagem { get; set; }
        public string Conexao { get; set; }
    }
}
