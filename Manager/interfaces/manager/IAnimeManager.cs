using Core.domain;
using CoreShared.modelsView.Animes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.manager
{
    public interface IAnimeManager
    {
        Task<ICollection<Anime>> GetAllAsync();
        Task<Anime> GetByIdAsync(int id);
        Task<Anime> PostAnimeAsync(NovoAnime novoAnime);
        Task<Anime> PutAnimeAsync(AlterarAnime alterarAnime);
    }
}
