namespace Core.domain
{
    public class Post
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string? ImgUrl { get; set; }
        public ICollection<Personagem> Estrelas { get; set; }
        public int PersonagemID { get; set; }
        public Personagem Personagem { get; set; }
        public Estado Estado { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }


    }
}