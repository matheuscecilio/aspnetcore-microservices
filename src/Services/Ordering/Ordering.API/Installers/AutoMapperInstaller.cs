using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ordering.API.Installers
{
    public static class AutoMapperInstaller
    {
        public static void InstallAutoMapper(this IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(executingAssembly);
        }
    }
}
