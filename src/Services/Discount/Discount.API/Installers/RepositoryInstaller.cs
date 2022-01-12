using Discount.API.Interfaces.Repositories;
using Discount.API.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.API.Installers
{
    public static class RepositoryInstaller
    {
        public static void InstallRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDiscountRepository, DiscountRepository>();
        }
    }
}
