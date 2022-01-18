using Discount.API.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Threading;

namespace Discount.API.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(
            this IHost host, 
            int? retry = 0
        )
        {
            var retryForAvailability = retry.Value;

            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;
            var configuration = services.GetRequiredService<IConfiguration>();
            var options = services.GetRequiredService<IOptions<PostGreeOptions>>();
            var logger = services.GetRequiredService<ILogger<TContext>>();

            try
            {
                logger.LogInformation("Migrating PostgreSql database.");

                using var connection = new NpgsqlConnection(options.Value.Connection);
                connection.Open();

                using var command = new NpgsqlCommand { Connection = connection };
                
                command.CommandText = "DROP TABLE IF EXISTS Coupon";
                command.ExecuteNonQuery();

                command.CommandText = @"CREATE TABLE Coupon(
                    Id SERIAL PRIMARY KEY,
                    ProductName VARCHAR(24) NOT NULL,
                    Description Text,
                    Amount INT
                )";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Coupon (ProductName, Description, Amount) VALUES ('Iphone X', 'Iphone Discount', 150);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Coupon (ProductName, Description, Amount) VALUES ('Iphone 13', 'Iphone 13 Discount', 230);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('Samsung 10', 'Samsung Discount', 100);";
                command.ExecuteNonQuery();

                logger.LogInformation("Magrated postgresql database.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating the postgresql database");

                if (retryForAvailability < 50)
                {
                    retryForAvailability++;
                    Thread.Sleep(2000);
                    MigrateDatabase<TContext>(
                        host,
                        retryForAvailability
                    );
                }
            }

            return host;
        }
    }
}
