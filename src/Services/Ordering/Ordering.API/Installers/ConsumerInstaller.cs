using Microsoft.Extensions.DependencyInjection;
using Ordering.API.EventBusConsumer;

namespace Ordering.API.Installers
{
    public static class ConsumerInstaller
    {
        public static void InstallConsumers(this IServiceCollection services)
        {
            services.AddScoped<BasketCheckoutConsumer>();
        }
    }
}
