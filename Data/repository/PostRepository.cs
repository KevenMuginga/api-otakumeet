using Core.domain;
using CoreShared.modelsView.posts;
using Data.context;
using Manager.interfaces.repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.repository
{
    public class PostRepository: IPostRepository
    {
        private readonly Context _context;
        public PostRepository(Context context) 
        {
            this._context = context;
        }

        public async Task<ICollection<Post>> GetAllAsync()
        {
            return await _context.Post
                .Include(p => p.Personagem)
                .Include(p => p.Estrelas)
                .Include(p => p.Comentarios)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<Post>> GetAllPostOfPersonagesFollowingAsync(int myId)
        {
            var me = await _context.Personagem.SingleOrDefaultAsync(p => p.Id == myId);

            return await _context.Post
                .Where(a => !a.Personagem.Seguidores.Contains(me) && a.PersonagemID != myId)
                .Include(p => p.Comentarios)
                .Include(p => p.Estrelas)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<Post>> GetAllPostPersonagemAsync(int Id)
        {
            return await _context.Post
                .Where(p => p.PersonagemID == Id)
                .Include(p => p.Personagem)
                .Include(p => p.Estrelas)
                .Include(p => p.Comentarios)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<Post>> GetSearchPostAsync(string word)
        {
            return await _context.Post
                .Where(p => p.Descricao.Contains(word))
                .Include(p => p.Personagem)
                .Include(p => p.Estrelas)
                .Include(p => p.Comentarios)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int Id)
        {
            return await _context.Post
                .Include(p => p.Personagem)
                .Include(p => p.Estrelas)
                .Include(p => p.Comentarios)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Post> PostAsync(Post post)
        {
            await InsertEstadoAsync(post, "ACTIVO");
            await _context.Post.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> PutAsync(Post post)
        {
            var postConsultado = await _context.Post.FindAsync(post.Id);
            if (postConsultado == null)
            {
                return null;
            }

            postConsultado = post;
            _context.Post.Attach(postConsultado);

            _context.Post.Entry(postConsultado).Property(p => p.Descricao).IsModified = true;
            _context.Post.Entry(postConsultado).Property(p => p.ImgUrl).IsModified = true;

            await _context.SaveChangesAsync();
            return post;
        }

        public async Task DeleteAsync(int Id)
        {
            var postConsultado = await _context.Post.FindAsync(Id);
            if (postConsultado == null)
            {

            }

            await InsertEstadoAsync(postConsultado, "ELIMINADO");
            await _context.SaveChangesAsync();
        }

        private async Task InsertEstadoAsync(Post post, string estado)
        {
            var estadoConsultado = await _context.Estado.SingleOrDefaultAsync(s => s.Descricao == estado);
            if (estadoConsultado == null)
            {

            }

            post.Estado = estadoConsultado;
        }

        public async Task AddEstarelaPostAsync(AddEstrela addEstrela)
        {
            var post = await _context.Post.FindAsync(addEstrela.PostId);
            var me = await _context.Personagem.FindAsync(addEstrela.MyId);
            post.Estrelas.Add(me);

            await _context.SaveChangesAsync();
        }
        public async Task RemoveEstrelaAsync(AddEstrela addEstrela)
        {
            var post = await _context.Post.FindAsync(addEstrela.PostId);
            var me = await _context.Personagem.FindAsync(addEstrela.MyId);
            post.Estrelas.Remove(me);

            await _context.SaveChangesAsync();
        }
    }
}
