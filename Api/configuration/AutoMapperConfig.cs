using Manager.mapping.anime;
using Manager.mapping.chats;
using Manager.mapping.comentarios;
using Manager.mapping.conexoes;
using Manager.mapping.estados;
using Manager.mapping.mensagens;
using Manager.mapping.personagens;
using Manager.mapping.posts;
using Manager.mapping.usuarios;

namespace Api.configuration
{
    public static class AutoMapperConfig
    {
        public static void UseAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(AnimeMappingProfile),
                typeof(ComentarioMappingProfile),
                typeof(PostMappingProfile),
                typeof(PersonagensMappingProfile),
                typeof(UsuareioMappingProfile),
                typeof(EstadoMappingProfile),
                typeof(ChatMappingProfile),
                typeof(MensagensMappingProfile),
                typeof(ConexaoPersonagemMappingProfile)
                );
        }
    }
}
