namespace Core.domain
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Estrelas { get; set; }
        public int PersonagemID { get; set; }
        public Personagem Personagem { get; set; }
        public int PostID { get; set; }
        public Post Post { get; set; }
        public Estado Estado { get; set; }
    }
}