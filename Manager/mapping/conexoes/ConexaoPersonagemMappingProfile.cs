using AutoMapper;
using Core.domain;
using CoreShared.modelsView.conexoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.mapping.conexoes
{
    public class ConexaoPersonagemMappingProfile: Profile
    {
        public ConexaoPersonagemMappingProfile()
        {
            CreateMap<ConexaoPersonagem, NovaConexao>().ReverseMap();
        }
    }
}
