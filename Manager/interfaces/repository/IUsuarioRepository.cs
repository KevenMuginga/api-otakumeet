using Core.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.repository
{
    public interface IUsuarioRepository
    {
        Task DeleteUsuarioAsync(int id);
        Task<ICollection<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int Id);
        Task<Usuario> GetByNomeAsync(string nome, string anime);
        Task<Usuario> PostAsync(Usuario usuario);
    }
}
