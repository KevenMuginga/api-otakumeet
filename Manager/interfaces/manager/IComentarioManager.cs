using Core.domain;
using CoreShared.modelsView.comentarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.manager
{
    public interface IComentarioManager
    {
        Task<ICollection<Comentario>> GetAllAsync(int id);
        Task<Comentario> PostComentarioAsync(NovoComentario novoComentario);
    }
}
