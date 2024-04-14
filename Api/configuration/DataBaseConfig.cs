using Data.context;
using Microsoft.EntityFrameworkCore;

namespace Api.configuration
{
    public static class DataBaseConfig
    {
        public static void UseDataBaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("default")));
        }
    }
}
