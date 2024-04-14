using Core.domain;
using CoreShared.modelsView.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.manager
{
    public interface IPersonagemManager
    {
        Task FollowPersonagemAsync(Follow follow);
        Task<ICollection<Personagem>> GetAllAsync();
        Task<ICollection<Personagem>> GetAllByAnimeAsync(int animeId);
        Task<ICollection<Personagem>> GetAllByAnimeWithoutUserAsync(int animeId);
        Task<ICollection<Personagem>> GetAllFollowingPersonageAsync(int myId);
        Task<ICollection<Personagem>> GetAllUnfofllowingPersonageAsync(int myId);
        Task<Personagem> GetByIdAsync(int id);
        Task<Personagem> PostPersnoangemAsync(NovaPersonagem novaPersonagem);
        Task StopFollowPersonagemAsync(Follow follow);
    }
}
