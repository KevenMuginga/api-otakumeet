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
    public class ConexaoPersonagemRepository: IConexaoPersonagemRepository
    {
        private readonly Context context;
        public ConexaoPersonagemRepository(Context context)
        {
            this.context = context;
        }

        public async Task<ICollection<ConexaoPersonagem>> GetAllAsync()
        {
            return await context.ConexaoPersonagem
                .Include(c => c.Personagem)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ConexaoPersonagem> GetByIdAsync(int id)
        {
            return await context.ConexaoPersonagem
                .Include(c => c.Personagem)
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.PersonagemId == id);
        }

        public async Task<ConexaoPersonagem> PostAsync(ConexaoPersonagem conexaoPersonagem)
        {
            await context.ConexaoPersonagem.AddAsync(conexaoPersonagem);
            await context.SaveChangesAsync();
            return conexaoPersonagem;
        }

        public async Task<ConexaoPersonagem> PutAsync(ConexaoPersonagem conexaoPersonagem)
        {
            var item = await context.ConexaoPersonagem.SingleOrDefaultAsync(c => c.PersonagemId == conexaoPersonagem.PersonagemId);
            if (item == null)
            {
                return null;
            }

            item.Conexao = conexaoPersonagem.Conexao;
            //context.ConexaoPersonagem.Attach(item);

            context.ConexaoPersonagem.Entry(item).State = EntityState.Modified;
            //context.Entry(item).CurrentValues.SetValues(conexaoPersonagem);        

            await context.SaveChangesAsync();
            return conexaoPersonagem;
        }
    }
}
