using EventBus.Messages.Common;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.API.EventBusConsumer;

namespace Ordering.API.Installers
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
                config.AddConsumer<BasketCheckoutConsumer>();

                config.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(hostAddress);
                    configurator.ReceiveEndpoint(
                        EventBusConstants.BasketCheckoutQueue,
                        c => c.ConfigureConsumer<BasketCheckoutConsumer>(context)
                    );
                });
            });

            services.AddMassTransitHostedService();
        }
    }
}
