using Core.domain;
using CoreShared.modelsView.conexoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.manager
{
    public interface IConexaoPersonagemManager
    {
        Task<ICollection<ConexaoPersonagem>> GetAllAsync();
        Task<ConexaoPersonagem> GetByIdAsync(int id);
        Task<ConexaoPersonagem> PostAsync(NovaConexao novaConexaoPersonagem);
        Task<ConexaoPersonagem> PutAsync(AlterarConexao alterarConexao);
    }
}
