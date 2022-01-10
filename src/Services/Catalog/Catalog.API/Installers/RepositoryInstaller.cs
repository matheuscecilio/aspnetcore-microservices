using Catalog.API.Interfaces.Repositories;
using Catalog.API.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.API.Installers
{
    public static class RepositoryInstaller
    {
        public static void InstallRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
