using Core.domain;
using CoreShared.modelsView.Personagens;
using Data.context;
using Manager.interfaces.repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Data.repository
{
    public class PersonagemRepository : IPersonagemRepository
    {
        private readonly Context context;
        public PersonagemRepository(Context context)
        {
            this.context = context;
        }

        public async Task<ICollection<Personagem>> GetAllAsync()
        {
            return await context.Personagem
                .Where(p => p.Nome != "Administrador")
                .Include(p => p.Anime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<Personagem>> GetAllByAnimeWithoutUserAsync(int animeId)
        {
            return await context.Personagem
                .Where(a => a.AnimeId == animeId && a.Usuario == null && a.Nome != "Administrador")
                .Include(p => p.Anime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<Personagem>> GetAllFollowingPersonageAsync(int myId)
        {
            var following = new List<Personagem>();
            var me = await context.Personagem.FindAsync(myId);

            return await context.Personagem
                .Where(a => a.Seguidores.Contains(me) && a.Id != myId && a.Nome != "Administrador")
                .Include(p => p.Anime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<Personagem>> GetAllUnfofllowingPersonageAsync(int myId)
        {
            var following = new List<Personagem>();
            var me = await context.Personagem.FindAsync(myId);

            return following = await context.Personagem
                .Where(a => !a.Seguidores.Contains(me) && a.Id != myId && a.Nome != "Administrador")
                .Include(p => p.Anime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<Personagem>> GetAllByAnimeAsync(int animeId)
        {
            return await context.Personagem
                .Where(a => a.AnimeId == animeId && a.Nome != "Administrador")
                .Include(p => p.Anime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Personagem> GetByIdAsync(int Id)
        {
            return await context.Personagem
                .Include(p => p.Anime)
                .Include(p => p.Usuario)
                .Include(p => p.Seguidores)
                .Include(p => p.ASeguir)
                .Include(p => p.Posts)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Personagem> GetByNomeAsync(string nome, string anime)
        {
            return await context.Personagem
                .Include(p => p.Anime)
                .Include(p => p.Usuario)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Nome.ToLower() == nome.ToLower() && p.Anime.Nome.ToLower() == anime.ToLower());
        }

        public async Task<Personagem> PostAsync(Personagem personagem)
        {
            await InsertEstadoAsync(personagem, "ACTIVO");
            await InsertAnimeAsync(personagem);
            var result = await context.Personagem.AddAsync(personagem);
            
            await context.SaveChangesAsync();
            return personagem;
        }

//        var result = await _userManager.CreateAsync(user, Model.Password);
//if (result.Succeeded)
//{
//    


        private async Task InsertAnimeAsync(Personagem personagem)
        {
            var animeCOnsultado = await context.Anime.FindAsync(personagem.AnimeId);
            if (animeCOnsultado == null)
            {

            }

            personagem.Anime = animeCOnsultado;
        }

        private async Task InsertEstadoAsync(Personagem personagem, string estado)
        {
            var estadoConsultado = await context.Estado.SingleOrDefaultAsync(s => s.Descricao == estado);
            if (estadoConsultado == null)
            {

            }

            personagem.Estado = estadoConsultado;
        }

        public async Task FollowPersonagemAsync(Follow follow)
        {
            var persnoagem = await context.Personagem
                .Include(p => p.Seguidores)
                .SingleOrDefaultAsync(p => p.Id == follow.PersonagemId);
            var me = await context.Personagem.FindAsync(follow.MyId);
            if (persnoagem == null || me == null)
            {
                
            }
            persnoagem.Seguidores.Add(me);

            await context.SaveChangesAsync();
        }

        public async Task StopFollowPersonagemAsync(Follow follow)
        {
            var persnoagem = await context.Personagem.Include(p => p.Seguidores).SingleOrDefaultAsync(p => p.Id == follow.PersonagemId);
            var me = await context.Personagem.Include(p => p.Seguidores).SingleOrDefaultAsync(p => p.Id == follow.MyId);
            persnoagem.Seguidores.Remove(me);

            await context.SaveChangesAsync();
        }
    }
}
