using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OcelotApiGw
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var environment = hostingContext.HostingEnvironment.EnvironmentName;
                    config.AddJsonFile($"ocelot.{environment}.json", true, true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging((hostingContext, loggingBuilder)  =>
                {
                    var loggingSection = hostingContext.Configuration.GetSection("Logging");
                    loggingBuilder.AddConfiguration(loggingSection);
                    loggingBuilder.AddConsole();
                    loggingBuilder.AddDebug();
                });
    }
}
