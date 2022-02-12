using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;

namespace OcelotApiGw.Installers
{
    public static class OcelotInstaller
    {
        public static void InstallOcelot(this IServiceCollection services)
        {
            services.AddOcelot();
        }
    }
}
