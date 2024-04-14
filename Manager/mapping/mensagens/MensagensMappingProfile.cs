using AutoMapper;
using Core.domain;
using CoreShared.modelsView.mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.mapping.mensagens
{
    public class MensagensMappingProfile : Profile
    {
        public MensagensMappingProfile()
        {
            CreateMap<Mensagem, NovaMensagem>().ReverseMap();
        }
    }
}
