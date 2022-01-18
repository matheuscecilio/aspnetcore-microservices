using Discount.GRPC.Interfaces.Repositories;
using Discount.GRPC.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.GRPC.Installers
{
    public static class RepositoryInstaller
    {
        public static void InstallRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDiscountRepository, DiscountRepository>();
        }
    }
}
