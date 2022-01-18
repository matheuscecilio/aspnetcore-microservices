using Discount.GRPC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Discount.GRPC.Installers
{
    public static class ServiceInstaller
    {
        public static void InstallServices(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGrpcService<DiscountService>();
        }
    }
}
