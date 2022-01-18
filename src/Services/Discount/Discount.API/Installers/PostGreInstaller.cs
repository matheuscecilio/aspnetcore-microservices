using Discount.API.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.API.Installers
{
    public static class PostGreInstaller
    {
        public static void InstallPostGre(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration.GetSection("DatabaseSettings:ConnectionString").Value;

            services.Configure<PostGreeOptions>(config =>
            {
                config.Connection = connectionString;
            });
        }
    }
}
