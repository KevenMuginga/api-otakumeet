using Core.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.repository
{
    public interface IComentarioRepository
    {
        Task DeleteAsync(int Id);
        Task<ICollection<Comentario>> GetAllOfPostAsync(int Id);
        Task<Comentario> PostAsync(Comentario comentario);
        Task<Comentario> PutAsync(Comentario comentario);
    }
}
