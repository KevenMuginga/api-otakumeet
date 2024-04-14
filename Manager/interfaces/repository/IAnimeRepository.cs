using Core.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.repository
{
    public interface IAnimeRepository
    {
        Task<ICollection<Anime>> GetAllAsync();
        Task<Anime> GetByIdAsync(int Id);
        Task<Anime> PostAsync(Anime anime);
        Task<Anime> PutAsync(Anime anime);
    }
}
