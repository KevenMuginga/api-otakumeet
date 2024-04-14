using Core.domain;
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
    public class ComentarioRepository: IComentarioRepository
    {
        private readonly Context _context;

        public ComentarioRepository(Context context)
        {
            this._context = context;
        }

        public async Task<ICollection<Comentario>> GetAllOfPostAsync(int Id)
        {
            return await _context.Comentario
                .Where(c => c.PostID == Id)
                .Include(p => p.Personagem)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Comentario> PostAsync(Comentario comentario)
        {
            await AlterEstadoAsync(comentario, "ACTIVO");
            await InsertPostAsync(comentario);
            await InsertPersonagemAsync(comentario);
            await _context.Comentario.AddAsync(comentario);
            await _context.SaveChangesAsync();
            return comentario;
        }

        private async Task InsertPostAsync(Comentario comentario)
        {
            var post = await _context.Post.SingleOrDefaultAsync(p => p.Id == comentario.PostID);
            if(post == null)
            {
                
            }

            comentario.Post = post;
        }

        private async Task InsertPersonagemAsync(Comentario comentario)
        {
            var item = await _context.Personagem.SingleOrDefaultAsync(p => p.Id == comentario.PersonagemID);
            if (item == null)
            {

            }

            comentario.Personagem = item;
        }

        public async Task<Comentario> PutAsync(Comentario comentario)
        {
            var comentarioConsultado = await _context.Comentario.FindAsync(comentario.Id);
            if (comentarioConsultado == null)
            {
                return null;
            }

            comentarioConsultado = comentario;
            _context.Comentario.Attach(comentarioConsultado);

            _context.Comentario.Entry(comentarioConsultado).Property(p => p.Descricao).IsModified = true;

            await _context.SaveChangesAsync();
            return comentario;
        }

        public async Task DeleteAsync(int Id)
        {
            var comentarioConsultado = await _context.Comentario.FindAsync(Id);
            if (comentarioConsultado == null)
            {

            }

            await AlterEstadoAsync(comentarioConsultado, "ELIMINADO");
            await _context.SaveChangesAsync();
        }

        private async Task AlterEstadoAsync(Comentario comentario, string estado)
        {
            var estadoConsultado = await _context.Estado.SingleOrDefaultAsync(s => s.Descricao == estado);
            if (estadoConsultado == null)
            {

            }

            comentario.Estado = estadoConsultado;
        }
    }
}
