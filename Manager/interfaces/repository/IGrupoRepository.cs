using Core.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.repository
{
    public interface IGrupoRepository
    {
        Task DeleteAsync(int id);
        Task<ICollection<Grupo>> GetAllByPersonagemIdAsync(int id);
        Task<Grupo> GetByIdAsync(int Id);
        Task<ICollection<Grupo>> GetByPersonagesAsync(Grupo chat);
        Task<Grupo> PostAsync(Grupo chat);
    }
}
