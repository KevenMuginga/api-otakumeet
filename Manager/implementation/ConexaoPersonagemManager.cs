using AutoMapper;
using Core.domain;
using CoreShared.modelsView.conexoes;
using CoreShared.modelsView.Personagens;
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
    public class ConexaoPersonagemManager : IConexaoPersonagemManager
    {
        private readonly IConexaoPersonagemRepository _repository;
        private readonly IMapper _mapper;

        public ConexaoPersonagemManager(IConexaoPersonagemRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<ICollection<ConexaoPersonagem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ConexaoPersonagem> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ConexaoPersonagem> PostAsync(NovaConexao conexaoPersonagem)
        {
            var item = _mapper.Map<ConexaoPersonagem>(conexaoPersonagem);
            return await _repository.PostAsync(item);
        }

        public async Task<ConexaoPersonagem> PutAsync(AlterarConexao alterarConexao)
        {
            var item = _mapper.Map<ConexaoPersonagem>(alterarConexao);
            return await _repository.PutAsync(item);
        }

    }
}
