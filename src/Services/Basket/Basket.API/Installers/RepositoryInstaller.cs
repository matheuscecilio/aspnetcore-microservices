using Basket.API.Interfaces.Repositories;
using Basket.API.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.API.Installers
{
    public static class RepositoryInstaller
    {
        public static void InstallRepositories(
            this IServiceCollection services
        )
        {
            services.AddScoped<IBasketRepository, BasketRepository>();
        }
    }
}
