using AutoMapper;
using Core.domain;
using CoreShared.modelsView.estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.mapping.estados
{
    public class EstadoMappingProfile: Profile
    {
        public EstadoMappingProfile() 
        {
            CreateMap<Estado, NovoEstado>().ReverseMap();
            CreateMap<Estado, AlterarEstado>().ReverseMap();
        }
    }
}
