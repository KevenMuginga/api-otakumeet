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
    public class MensagemRepository : IMensagemRepository
    {
        private readonly Context context;
        public MensagemRepository(Context context)
        {
            this.context = context;
        }

        public async Task<ICollection<Mensagem>> GetAllByChatIdAsync(int id)
        {
            return await context.Mensagem
                .Where(m => m.ToGrupoId == id)
                .Include(a => a.Personagem)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<Mensagem>> GetAllByChatAsync(Grupo chat)
        {
            return await context.Mensagem
                .Where(c => c.ToGrupo.PrimeiraPersonagemId == chat.PrimeiraPersonagemId && c.ToGrupo.SegundaPersonagemId == chat.SegundaPersonagemId)
                .Include(c => c.Personagem)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Mensagem> PostAsync(Mensagem mensagem)
        {
            await InsertEstadoAsync(mensagem, "ACTIVO");
            await InsertGrupoAsync(mensagem);
            await InsertPersonagemAsync(mensagem);
            await context.Mensagem.AddAsync(mensagem);
            await context.SaveChangesAsync();
            return mensagem;
        }

        private async Task InsertEstadoAsync(Mensagem mensagem, string estado)
        {
            var estadoConsultado = await context.Estado.SingleOrDefaultAsync(s => s.Descricao == estado);
            if (estadoConsultado == null)
            {

            }

            mensagem.Estado = estadoConsultado;
        }

        private async Task InsertPersonagemAsync(Mensagem mensagem)
        {
            var item = await context.Personagem.SingleOrDefaultAsync(s => s.Id == mensagem.PersonagemId);
            if (item == null)
            {

            }

            mensagem.Personagem = item;
        }

        private async Task InsertGrupoAsync(Mensagem mensagem)
        {
            var item = await context.Grupo.SingleOrDefaultAsync(s => s.Id == mensagem.ToGrupoId);
            if (item == null)
            {

            }

            mensagem.ToGrupo = item;
        }
    }
}
