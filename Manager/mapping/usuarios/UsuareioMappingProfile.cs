using AutoMapper;
using Core.domain;
using CoreShared.modelsView.usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.mapping.usuarios
{
    public class UsuareioMappingProfile: Profile
    {
        public UsuareioMappingProfile()
        {
            CreateMap<Usuario, NovoUsuario>().ReverseMap();
            CreateMap<Usuario, LoginUsuario>().ReverseMap();
        }
    }
}
