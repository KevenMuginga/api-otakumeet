using Data.repository;
using Data.services;
using Manager.implementation;
using Manager.interfaces.manager;
using Manager.interfaces.repository;
using Manager.interfaces.services;

namespace Api.configuration
{
    public static class DependencyInjectionConfig
    {
        public static void UseDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAnimeRepository, AnimeRepository>();
            services.AddScoped<IAnimeManager, AnimeManager>();

            services.AddScoped<IPersonagemRepository, PersonagemRepository>();
            services.AddScoped<IPersonagemManager, PersonagemManager>();

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostManager, PostManager>();

            services.AddScoped<IComentarioRepository, ComentarioRepository>();
            services.AddScoped<IComentarioManager, ComentarioManager>();

            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IEstadoManager, EstadoManager>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioManager, UsuarioManager>();

            services.AddScoped<IGrupoRepository, GrupoRepository>();
            services.AddScoped<IGrupoManager, GrupoManager>();

            services.AddScoped<IMensagemRepository, MensagemRepository>();
            services.AddScoped<IMensagemManager, MensagemManager>();

            services.AddScoped<IConexaoPersonagemRepository, ConexaoPersonagemRepository>();
            services.AddScoped<IConexaoPersonagemManager, ConexaoPersonagemManager>();

            services.AddScoped<ILoginManager, LoginManager>();

            services.AddScoped<IChatHubManager, ChatHubManager>();

            services.AddScoped<IJwtService, JwtService>();


        }
    }
}
