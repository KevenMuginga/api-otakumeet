using AutoMapper;
using Core.domain;
using CoreShared.modelsView.Animes;
using Manager.interfaces.manager;
using Manager.interfaces.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.implementation
{
    public class AnimeManager: IAnimeManager
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly IMapper _mapper;
        private string urlPath = "C:/xampp/htdocs/otakumeet/";

        public AnimeManager(IAnimeRepository animeRepository, IMapper mapper)
        {
            this._animeRepository = animeRepository;
            this._mapper = mapper;
        }

        public async Task<ICollection<Anime>> GetAllAsync()
        {
            return await _animeRepository.GetAllAsync();
        }

        public async Task<Anime> GetByIdAsync(int id)
        {
            return await _animeRepository.GetByIdAsync(id);
        }

        public async Task<Anime> PostAnimeAsync(NovoAnime novoAnime)
        {
            var anime = _mapper.Map<Anime>(novoAnime);
            anime.ImgUrl = await uploadImage(novoAnime);
            return await _animeRepository.PostAsync(anime);
        }

        public async Task<Anime> PutAnimeAsync(AlterarAnime alterarAnime)
        {
            var anime = _mapper.Map<Anime>(alterarAnime);
            anime.ImgUrl = await uploadImage(_mapper.Map<NovoAnime>(alterarAnime));
            return await _animeRepository.PutAsync(anime);
        }

        public async Task<string> uploadImage(NovoAnime novoAnime)
        {
            if (novoAnime.File == null)
            {
                return null;
            }

            var path = Path.Combine(urlPath, novoAnime.File.FileName);
            using(var fileStream = new FileStream(path, FileMode.Create))
            {
                await novoAnime.File.CopyToAsync(fileStream);
                fileStream.Close();
            }

            return Path.Combine("http://127.0.0.1:5501/otakumeet/" + novoAnime.File.FileName);
        }
    }
}
