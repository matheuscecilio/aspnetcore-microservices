using Discount.Grpc.Protos;
using System.Threading.Tasks;

namespace Basket.API.Interfaces.GrpcServices
{
    public interface IDiscountGrpcService
    {
        Task<CouponModel> GetDiscount(string productName);
    }
}
