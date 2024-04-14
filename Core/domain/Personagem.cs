namespace Core.domain
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? ImgUrl { get; set; }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }
        public Usuario Usuario{ get; set; }
        public Estado Estado { get; set; }
        public ConexaoPersonagem? ConexaoPersonagem { get; set; }
        public ICollection<Personagem> ASeguir { get; set; }
        public ICollection<Personagem> Seguidores { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}