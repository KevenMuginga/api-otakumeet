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
    public class GrupoRepository : IGrupoRepository
    {
        private readonly Context context;
        public GrupoRepository(Context context)
        {
            this.context = context;
        }

        public async Task<ICollection<Grupo>> GetByPersonagesAsync(Grupo chat)
        {
            return await context.Grupo
                .Where(c => c.PrimeiraPersonagemId == chat.PrimeiraPersonagemId && c.SegundaPersonagemId == chat.SegundaPersonagemId)
                .Include(a => a.PrimeiraPersonagem)
                .Include(a => a.SegundaPersonagem)
                .Include(a => a.Mensagens)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<Grupo>> GetByGrupoAsync(Grupo chat)
        {
            return await context.Grupo
                .Where(c => (c.PrimeiraPersonagemId == chat.PrimeiraPersonagemId || c.PrimeiraPersonagemId == chat.SegundaPersonagemId) && (c.SegundaPersonagemId == chat.SegundaPersonagemId || c.SegundaPersonagemId == chat.PrimeiraPersonagemId))
                .Include(a => a.PrimeiraPersonagem)
                .Include(a => a.SegundaPersonagem)
                .Include(a => a.Mensagens)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<Grupo>> GetAllByPersonagemIdAsync(int id)
        {
            return await context.Grupo
                .Where(c => c.PrimeiraPersonagemId == id || c.SegundaPersonagemId == id)
                .Include(a => a.PrimeiraPersonagem)
                .Include(a => a.SegundaPersonagem)
                .Include(a => a.Mensagens)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Grupo> GetByIdAsync(int Id)
        {
            return await context.Grupo
                .Include(a => a.PrimeiraPersonagem)
                .Include(a => a.SegundaPersonagem)
                .Include(a => a.Mensagens)
                .AsNoTracking()
                .SingleOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<Grupo> PostAsync(Grupo chat)
        {
            chat.PrimeiraPersonagem = await InsertPersonagemAsync(chat.PrimeiraPersonagemId);
            chat.SegundaPersonagem = await InsertPersonagemAsync(chat.SegundaPersonagemId);
            chat.Nome = chat.PrimeiraPersonagem.Nome + "_" + chat.SegundaPersonagem.Nome;
            await InsertEstadoAsync(chat, "ACTIVO");
            await context.Grupo.AddAsync(chat);
            await context.SaveChangesAsync();
            return chat;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await context.Grupo.FindAsync(id);
            if (item == null )
            {

            }
            context.Grupo.Remove(item);
            await context.SaveChangesAsync();

        }

        private async Task InsertEstadoAsync(Grupo chat, string estado)
        {
            var estadoConsultado = await context.Estado.SingleOrDefaultAsync(s => s.Descricao == estado);
            if (estadoConsultado == null)
            {

            }

            chat.Estado = estadoConsultado;
        }

        private async Task<Personagem> InsertPersonagemAsync(int id)
        {
            var personagem = await context.Personagem.FindAsync(id);
            if (personagem == null)
            {

            }

            return personagem;
        }
    }
}
