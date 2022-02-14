using AspnetRunBasics.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspnetRunBasics.Installers
{
    public static class HttpClientInstaller
    {
        public static void InstallHttpClient(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var gatewayAddress = configuration["ApiSettings:GatewayAddress"];

            services.AddHttpClient<ICatalogService, CatalogService>(x =>
                x.BaseAddress = new Uri(gatewayAddress)
            );

            services.AddHttpClient<IBasketService, BasketService>(x =>
                x.BaseAddress = new Uri(gatewayAddress)
            );

            services.AddHttpClient<IOrderService, OrderService>(x =>
                x.BaseAddress = new Uri(gatewayAddress)
            );
        }
    }
}
