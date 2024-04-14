using AutoMapper;
using Core.domain;
using CoreShared.modelsView.Animes;
using CoreShared.modelsView.chats;
using CoreShared.modelsView.Personagens;
using Manager.interfaces.manager;
using Manager.interfaces.repository;
using Microsoft.AspNetCore.Identity;

namespace Manager.implementation
{
    public class PersonagemManager: IPersonagemManager
    {
        private readonly IPersonagemRepository _repository;
        private readonly IConexaoPersonagemRepository _conexaorepository;
        private readonly IGrupoRepository _chatRepository;
        private readonly IMapper _mapper;
        private string urlUpload = "C:/xampp/htdocs/otakumeet/";

        public PersonagemManager(IPersonagemRepository repository, IMapper mapper, IGrupoRepository _chatRepository, IConexaoPersonagemRepository conexaorepository)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._chatRepository = _chatRepository;
            this._conexaorepository = conexaorepository;
        }

        public async Task<ICollection<Personagem>> GetAllByAnimeAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ICollection<Personagem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ICollection<Personagem>> GetAllFollowingPersonageAsync(int myId)
        {
            return await _repository.GetAllFollowingPersonageAsync(myId);
        }

        public async Task<ICollection<Personagem>> GetAllUnfofllowingPersonageAsync(int myId)
        {
            return await _repository.GetAllUnfofllowingPersonageAsync(myId);
        }

        public async Task<ICollection<Personagem>> GetAllByAnimeWithoutUserAsync(int animeId)
        {
            return await _repository.GetAllByAnimeWithoutUserAsync(animeId);
        }

        public async Task<ICollection<Personagem>> GetAllByAnimeAsync(int animeId)
        {
            return await _repository.GetAllByAnimeAsync(animeId);
        }

        public async Task<Personagem> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Personagem> PostPersnoangemAsync(NovaPersonagem novaPersonagem)
        {
            var item = _mapper.Map<Personagem>(novaPersonagem);
            item.ImgUrl = await UploadFile(novaPersonagem);
            return await _repository.PostAsync(item);
        }

        public async Task FollowPersonagemAsync(Follow follow)
        {
            var novoChat = new Grupo()
            {
                PrimeiraPersonagemId = follow.MyId,
                SegundaPersonagemId = follow.PersonagemId,
            };

            var chat = await _chatRepository.PostAsync(novoChat);

            //var primeiraConexao = await _conexaorepository.GetByIdAsync(novoChat.PrimeiraPersonagemId);
            //var segundaConexao = await _conexaorepository.GetByIdAsync(novoChat.SegundaPersonagemId);

            await _repository.FollowPersonagemAsync(follow);
        }

        public async Task StopFollowPersonagemAsync(Follow follow)
        {
            await _repository.StopFollowPersonagemAsync(follow);
        }

        public async Task<string> UploadFile(NovaPersonagem novaPersonagem)
        {
            if (novaPersonagem.File == null)
            {
                return null;
            }

            var path = Path.Combine(urlUpload, novaPersonagem.File.FileName);
            using(var fileStream = new FileStream(path, FileMode.Create))
            {
                await novaPersonagem.File.CopyToAsync(fileStream);
                fileStream.Close();
            }

            return Path.Combine("http://127.0.0.1:5501/otakumeet/" + novaPersonagem.File.FileName);
        }

    }
}
