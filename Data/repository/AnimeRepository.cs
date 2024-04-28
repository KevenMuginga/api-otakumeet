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
    public class AnimeRepository: IAnimeRepository
    {
        private readonly Context context;
        public AnimeRepository(Context context)
        {
            this.context = context;
        }

        public async Task<ICollection<Anime>> GetAllAsync()
        {
            return await context.Anime
                .Where(a => a.Nome != "Administrador")
                .Include(a => a.Personagens)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Anime> GetByIdAsync(int Id)
        {
            return await context.Anime
                .Include(a => a.Personagens)
                .AsNoTracking()
                .SingleOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<Anime> PostAsync(Anime anime)
        {
            await InsertEstadoAsync(anime, "ACTIVO");
            await context.Anime.AddAsync(anime);
            await context.SaveChangesAsync();
            return anime;
        }

        public async Task<Anime> PutAsync(Anime anime)
        {
            var animeConsultado = await context.Anime.FindAsync(anime.Id);
            if (animeConsultado == null)
            {
                return null;
            }

            animeConsultado.Nome = anime.Nome;
            animeConsultado.Autor = anime.Autor;
            animeConsultado.ImgUrl = anime.ImgUrl;

            //context.Attach(animeConsultado);
            //context.Anime.Entry(animeConsultado).Property(a => a.Nome).IsModified = true;
            //context.Anime.Entry(animeConsultado).Property(a => a.Autor).IsModified = true;
            //context.Anime.Entry(animeConsultado).Property(a => a.ImgUrl).IsModified = true;

            context.SaveChanges();
            return anime;
        }

        private async Task InsertEstadoAsync(Anime anime, string estado)
        {
            var estadoConsultado = await context.Estado.SingleOrDefaultAsync(s => s.Descricao == "ACTIVO");
            if (estadoConsultado == null)
            {

            }

            anime.Estado = estadoConsultado;
        }
    }
}
