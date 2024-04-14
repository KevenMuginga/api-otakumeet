using Core.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.repository
{
    public interface IConexaoPersonagemRepository
    {
        Task<ICollection<ConexaoPersonagem>> GetAllAsync();
        Task<ConexaoPersonagem> GetByIdAsync(int id);
        Task<ConexaoPersonagem> PostAsync(ConexaoPersonagem conexaoPersonagem);
        Task<ConexaoPersonagem> PutAsync(ConexaoPersonagem conexaoPersonagem);
    }
}
