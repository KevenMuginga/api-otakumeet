namespace Core.domain
{
    public class Mensagem
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int PersonagemId { get; set; }
        public Personagem Personagem { get; set; }
        public int ToGrupoId { get; set; }
        public Grupo ToGrupo{ get; set; }
        public Estado Estado { get; set; }
        public DateTime Data { get; set; }

    }
}