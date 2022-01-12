using Discount.API.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.API.Installers
{
    public static class PostGreeInstaller
    {
        public static void InstallPostGree(
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
