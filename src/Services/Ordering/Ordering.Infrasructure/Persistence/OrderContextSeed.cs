using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrasructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(
            OrderContext context,
            ILogger<OrderContextSeed> logger
        )
        {
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(GetDefaultOrders());
                await context.SaveChangesAsync();
                logger.LogInformation($"Seed database associated with context {typeof(OrderContext).Name}");
            }
        }

        private static IEnumerable<Order> GetDefaultOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    UserName = "matheus.cecilio",
                    FirstName = "Matheus",
                    LastName = "Cecilio",
                    EmailAddress = "email@gmail.com",
                    AddressLine = "address.line",
                    Country = "Brazil",
                    TotalPrice = 450
                }
            };
        }
    }
}
