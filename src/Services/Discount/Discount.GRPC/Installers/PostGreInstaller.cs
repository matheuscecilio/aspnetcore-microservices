using Discount.GRPC.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.GRPC.Installers
{
    public static class PostGreInstaller
    {
        public static void InstallPostGreSql(
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
