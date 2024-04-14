using AutoMapper;
using Core.domain;
using CoreShared.modelsView.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.mapping.personagens
{
    public class PersonagensMappingProfile : Profile
    {
        public PersonagensMappingProfile()
        {
            CreateMap<Personagem, NovaPersonagem>().ReverseMap();
            CreateMap<Personagem, AlterarPersonagem>().ReverseMap();
            CreateMap<Personagem, PersonagemView>().ReverseMap();
            CreateMap<Personagem, PersonagemLogada>().ReverseMap();
            CreateMap<Personagem, LoginPersonagem>().ReverseMap();
        }
    }
}
