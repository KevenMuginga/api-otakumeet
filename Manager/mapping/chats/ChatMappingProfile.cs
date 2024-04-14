using AutoMapper;
using Core.domain;
using CoreShared.modelsView.chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.mapping.chats
{
    public class ChatMappingProfile: Profile
    {
        public ChatMappingProfile() 
        {
            CreateMap<Grupo, NovoGrupo>().ReverseMap();
        }
    }
}
