using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Threading.Tasks;

namespace OcelotApiGw.Installers
{
    public static class OcelotInstaller
    {
        public static void InstallOcelot(this IServiceCollection services)
        {
            services.AddOcelot();
        }

        public static async Task ConfigureOcelot(this IApplicationBuilder app)
        {
            await app.UseOcelot();
        }
    }
}
