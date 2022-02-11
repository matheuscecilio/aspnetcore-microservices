using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.API.Installers
{
    public static class RabbitMqInstaller
    {
        public static void InstallMassTransit(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var hostAddress = configuration["EventBusSettings:HostAddress"];
            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(hostAddress);
                });
            });

            services.AddMassTransitHostedService();
        }
    }
}
