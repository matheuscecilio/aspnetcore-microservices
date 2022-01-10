using Catalog.API.Data;
using Catalog.API.Interfaces.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.API.Installers
{
    public static class MongoInstaller
    {
        public static void InstallMongo(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration.GetSection("MongoDbSettings:ConnectionString").Value;
            var database = configuration.GetSection("MongoDbSettings:Database").Value;

            services.Configure<MongoOptions>(config =>
            {
                config.Connection = connectionString;
                config.Database = database;
            });

            services.AddScoped<ICatalogContext, CatalogContext>();
        }
    }
}
