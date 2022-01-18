using Basket.API.GrpcServices;
using Basket.API.Interfaces.GrpcServices;
using Discount.Grpc.Protos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.API.Installers
{
    public static class GrpcInstaller
    {
        public static void InstallGrpc(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var discountUrl = configuration["GrpcSettings:DiscountUrl"];

            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(
                options => options.Address = new(discountUrl)
            );

            services.AddScoped<IDiscountGrpcService, DiscountGrpcService>();
        }
    }
}
