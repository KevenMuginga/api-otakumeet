using AutoMapper;
using Core.domain;
using CoreShared.modelsView.mensagens;
using Manager.interfaces.manager;
using Manager.interfaces.repository;

namespace Manager.implementation
{
    public class MensagemManager: IMensagemManager
    {
        private readonly IMensagemRepository _repository;
        private readonly IMapper _mapper;


        public MensagemManager(IMensagemRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<ICollection<Mensagem>> GetAllByChatAsync(Grupo chat)
        {
            return await _repository.GetAllByChatAsync(chat);
        }

        public async Task<ICollection<Mensagem>> GetAllByChatAsync(int id)
        {
            return await _repository.GetAllByChatIdAsync(id);
        }

        public async Task<Mensagem> PostAsync(NovaMensagem novaMensagem)
        {
            var mensagem =  _mapper.Map<Mensagem>(novaMensagem);
            return await _repository.PostAsync(mensagem);
        }
    }
}
