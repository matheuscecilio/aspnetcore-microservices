using Dapper;
using Discount.GRPC.Data;
using Discount.GRPC.Entities;
using Discount.GRPC.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Threading.Tasks;

namespace Discount.GRPC.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly string _connectionString;

        public DiscountRepository(IOptions<PostGreeOptions> postGreeOptions)
        {
            _connectionString = postGreeOptions.Value.Connection;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var query = "INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount);";

            var parameters = new
            {
                coupon.ProductName,
                coupon.Description,
                coupon.Amount
            };

            var affected = await connection.ExecuteAsync(
                query,
                parameters
            );

            return affected > 0;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var query = "DELETE FROM Coupon WHERE ProductName=@ProductName;";

            var parameters = new
            {
                ProductName = productName
            };

            var affected = await connection.ExecuteAsync(
                query,
                parameters
            );

            return affected > 0;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var parameters = new
            {
                ProductName = productName
            };

            var query = "SELECT * FROM Coupon WHERE ProductName = @ProductName;";

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(
                query,
                parameters
            );

            if (coupon is null)
            {
                return new Coupon
                {
                    Amount = 0,
                    ProductName = "No Discount",
                    Description = "No Discount Description"
                };
            }

            return coupon;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var query = "UPDATE Coupon SET ProductName=@ProductName, Description=@Description, Amount=@Amount WHERE Id=@Id;";

            var parameters = new
            {
                coupon.Id,
                coupon.ProductName,
                coupon.Description,
                coupon.Amount
            };

            var affected = await connection.ExecuteAsync(
                query,
                parameters
            );

            return affected > 0;
        }
    }
}
