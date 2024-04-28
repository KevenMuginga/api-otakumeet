using AutoMapper;
using Core.domain;
using CoreShared.modelsView.Animes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.mapping.anime
{
    public class AnimeMappingProfile : Profile
    {
        public AnimeMappingProfile()
        {
            CreateMap<Anime, NovoAnime>().ReverseMap();
            CreateMap<Anime, AnimeView>().ReverseMap();
            CreateMap<Anime, NovoAnime>().ReverseMap();
            CreateMap<Anime, AlterarAnime>().ReverseMap();
            CreateMap<AlterarAnime, NovoAnime>().ReverseMap();
        }
    }
}
