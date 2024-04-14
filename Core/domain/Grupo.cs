namespace Core.domain
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PrimeiraPersonagemId { get; set; }
        public Personagem PrimeiraPersonagem { get; set; }
        public int SegundaPersonagemId { get; set; }
        public Personagem SegundaPersonagem { get; set; }
        public Estado Estado { get; set; }
        public ICollection<Mensagem> Mensagens { get; set; }
    }
}
