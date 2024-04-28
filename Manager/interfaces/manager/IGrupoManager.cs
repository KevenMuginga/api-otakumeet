using Core.domain;
using CoreShared.modelsView.chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.manager
{
    public interface IGrupoManager
    {
        Task DeleteAsync(int id);
        Task<ICollection<Grupo>> get(Grupo chat);
        Task<ICollection<Grupo>> GetAllByPersonagemIdAsync(int id);
        Task<ICollection<Grupo>> GetByGrupoAsync(NovoGrupo grupo);
        Task<Grupo> GetByIdAsync(int id);
        Task<Grupo> PostAsync(NovoGrupo novoChat);
    }
}
