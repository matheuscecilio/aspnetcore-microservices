using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Contracts.Infrasructure;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Models;
using Ordering.Infrasructure.Mail;
using Ordering.Infrasructure.Persistence;
using Ordering.Infrasructure.Repositories;

namespace Ordering.Infrasructure.Installers
{
    public static class InfrastructureInstaller
    {
        public static void InstallInsfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration.GetConnectionString("OrderingConnectionString");
            services.AddDbContext<OrderContext>(opt => opt.UseSqlServer(connectionString));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
