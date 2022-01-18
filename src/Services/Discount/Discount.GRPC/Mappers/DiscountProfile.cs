using AutoMapper;
using Discount.Grpc.Protos;
using Discount.GRPC.Entities;

namespace Discount.GRPC.Mappers
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
