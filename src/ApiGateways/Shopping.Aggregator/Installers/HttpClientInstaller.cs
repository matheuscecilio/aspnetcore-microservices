using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Aggregator.Services;
using System;

namespace Shopping.Aggregator.Installers
{
    public static class HttpClientInstaller
    {
        public static void InstallHttpClient(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var catalogUrl = configuration["ApiSettings:CatalogUrl"];
            var basketUrl = configuration["ApiSettings:BasketUrl"];
            var orderingUrl = configuration["ApiSettings:OrderingUrl"];

            services.AddHttpClient<ICatalogService, CatalogService>(x => 
                x.BaseAddress = new Uri(catalogUrl)
            );

            services.AddHttpClient<IBasketService, BasketService>(x =>
                x.BaseAddress = new Uri(basketUrl)
            );

            services.AddHttpClient<IOrderService, OrderService>(x =>
                x.BaseAddress = new Uri(orderingUrl)
            );
        }
    }
}
