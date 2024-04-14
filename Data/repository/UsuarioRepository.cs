using Core.domain;
using CoreShared.modelsView.Personagens;
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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Context context;
        public UsuarioRepository(Context context)
        {
            this.context = context;
        }

        public async Task<ICollection<Usuario>> GetAllAsync()
        {
            return await context.Usuario
                .Include(p => p.Personagem)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int Id)
        {
            return await context.Usuario
                .Include(p => p.Personagem)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Usuario> GetByNomeAsync(string nome, string anime)
        {
            return await context.Usuario
                .Include(p => p.Personagem)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Nome == nome );
        }

        public async Task<Usuario> PostAsync(Usuario usuario)
        {
            await InsertEstadoAsync(usuario, "ACTIVO");
            await context.Usuario.AddAsync(usuario);
            await PostUsuarioPersonagemAsync(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }

        private async Task PostUsuarioPersonagemAsync(Usuario usuario)
        {
            var personagem = await context.Personagem.FindAsync(usuario.PersonagemId);
            if (personagem == null)
            {

            }

            usuario.Personagem = personagem;
        }

        private async Task InsertEstadoAsync(Usuario usuario, string estado)
        {
            var estadoConsultado = await context.Estado.SingleOrDefaultAsync(s => s.Descricao == estado);
            if (estadoConsultado == null)
            {

            }

            usuario.Estado = estadoConsultado;
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            var usuario = await context.Usuario.FindAsync(id);
            if (usuario == null)
            {

            }

            await InsertEstadoAsync(usuario, "ELIMINADO");
            await context.SaveChangesAsync();

        }
    }
}
