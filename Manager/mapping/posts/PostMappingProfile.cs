using AutoMapper;
using Core.domain;
using CoreShared.modelsView.posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.mapping.posts
{
    public class PostMappingProfile: Profile
    {
        public PostMappingProfile() 
        {
            CreateMap<Post, NovoPost>().ReverseMap();
            CreateMap<Post, AlterarPost>().ReverseMap();
            CreateMap<Post, PostView>().ReverseMap();
        }
    }
}
