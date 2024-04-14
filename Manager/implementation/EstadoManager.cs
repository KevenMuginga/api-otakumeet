using AutoMapper;
using Core.domain;
using CoreShared.modelsView.estados;
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
    public class EstadoManager: IEstadoManager
    {
        private readonly IEstadoRepository _repository;
        private readonly IMapper _mapper;

        public EstadoManager(IEstadoRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<ICollection<Estado>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Estado> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Estado> PostPostAsync(NovoEstado novoEstado)
        {
            var item = _mapper.Map<Estado>(novoEstado);
            return await _repository.PostAsync(item);
        }

        public async Task<Estado> PutPostAsync(AlterarEstado alterarEstado)
        {
            var item = _mapper.Map<Estado>(alterarEstado);
            return await _repository.PutAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
