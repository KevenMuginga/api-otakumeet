using Core.domain;
using CoreShared.modelsView.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.repository
{
    public interface IPersonagemRepository
    {
        Task FollowPersonagemAsync(Follow follow);
        Task<ICollection<Personagem>> GetAllAsync();
        Task<ICollection<Personagem>> GetAllByAnimeAsync(int animeId);
        Task<ICollection<Personagem>> GetAllByAnimeWithoutUserAsync(int animeId);
        Task<ICollection<Personagem>> GetAllFollowingPersonageAsync(int myId);
        Task<ICollection<Personagem>> GetAllUnfofllowingPersonageAsync(int myId);
        Task<Personagem> GetByIdAsync(int Id);
        Task<Personagem> GetByNomeAsync(string nome, string anime);
        Task<Personagem> PostAsync(Personagem personagem);
        Task StopFollowPersonagemAsync(Follow follow);
    }
}
