using Core.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.repository
{
    public interface IEstadoRepository
    {
        Task DeleteAsync(int Id);
        Task<ICollection<Estado>> GetAllAsync();
        Task<Estado> GetByIdAsync(int Id);
        Task<Estado> PostAsync(Estado estado);
        Task<Estado> PutAsync(Estado estado);
    }
}
