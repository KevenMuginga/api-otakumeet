using AutoMapper;
using Core.domain;
using CoreShared.modelsView.comentarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.mapping.comentarios
{
    public class ComentarioMappingProfile: Profile
    {
        public ComentarioMappingProfile() 
        {
            CreateMap<Comentario, NovoComentario>().ReverseMap();
        }
    }
}
