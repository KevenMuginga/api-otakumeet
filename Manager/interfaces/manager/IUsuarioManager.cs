using Core.domain;
using CoreShared.modelsView.usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.manager
{
    public interface IUsuarioManager
    {
        Task DeleteUsuarioAsync(int id);
        Task<ICollection<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task<Usuario> PostPersnoangemAsync(NovoUsuario novoUsuario);
    }
}
