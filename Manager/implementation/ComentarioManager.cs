using AutoMapper;
using Core.domain;
using CoreShared.modelsView.comentarios;
using CoreShared.modelsView.posts;
using Manager.interfaces.manager;
using Manager.interfaces.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.implementation
{
    public class ComentarioManager: IComentarioManager
    {
        private readonly IComentarioRepository _repository;
        private readonly IMapper _mapper;

        public ComentarioManager(IComentarioRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<ICollection<Comentario>> GetAllAsync(int id)
        {
            return await _repository.GetAllOfPostAsync(id);
        }

        public async Task<Comentario> PostComentarioAsync(NovoComentario novoComentario)
        {
            var item = _mapper.Map<Comentario>(novoComentario);
            return await _repository.PostAsync(item);
        }
    }
}
