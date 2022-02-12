using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Cache.CacheManager;
using Ocelot.Middleware;
using System.Threading.Tasks;

namespace OcelotApiGw.Installers
{
    public static class OcelotInstaller
    {
        public static void InstallOcelot(this IServiceCollection services)
        {
            services.AddOcelot()
                .AddCacheManager(settings => settings.WithDictionaryHandle());
        }

        public static async Task ConfigureOcelot(this IApplicationBuilder app)
        {
            await app.UseOcelot();
        }
    }
}
