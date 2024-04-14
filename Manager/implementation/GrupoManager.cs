using AutoMapper;
using Core.domain;
using CoreShared.modelsView.chats;
using Manager.interfaces.manager;
using Manager.interfaces.repository;

namespace Manager.implementation
{
    public class GrupoManager: IGrupoManager
    {
        private readonly IGrupoRepository _repository;
        private readonly IMapper _mapper;

        public GrupoManager(IGrupoRepository repository, IMapper mapper)
        {
            this._repository  = repository;
            this._mapper = mapper;
        }

        public async Task<ICollection<Grupo>> get(Grupo chat)
        {
            return await _repository.GetByPersonagesAsync(chat);
        }

        public async Task<Grupo> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ICollection<Grupo>> GetAllByPersonagemIdAsync(int id)
        {
            return await _repository.GetAllByPersonagemIdAsync(id);
        }

        public async Task<Grupo> PostAsync(NovoGrupo novoChat)
        {
            var chat = _mapper.Map<Grupo>(novoChat);
            return await _repository.PostAsync(chat);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
