using Core.domain;
using CoreShared.modelsView.estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.manager
{
    public interface IEstadoManager
    {
        Task DeleteAsync(int id);
        Task<ICollection<Estado>> GetAllAsync();
        Task<Estado> GetByIdAsync(int id);
        Task<Estado> PostPostAsync(NovoEstado novoEstado);
        Task<Estado> PutPostAsync(AlterarEstado alterarEstado);
    }
}
