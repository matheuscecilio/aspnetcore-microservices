using AutoMapper;
using Discount.Grpc.Protos;
using Discount.GRPC.Entities;
using Discount.GRPC.Interfaces.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Discount.GRPC.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DiscountService> _logger;

        public DiscountService(
            IDiscountRepository discountRepository,
            ILogger<DiscountService> logger, 
            IMapper mapper
        )
        {
            _discountRepository = discountRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<CouponModel> GetDiscount(
            GetDiscountRequest request, 
            ServerCallContext context
        )
        {
            var coupon = await _discountRepository.GetDiscount(
                request.ProductName
            );

            if (coupon is null)
            {
                var notFound = new Status(
                    StatusCode.NotFound,
                    $"Discount with ProductName{request.ProductName} is not found."
                );

                throw new RpcException(notFound);
            }

            _logger.LogInformation($"Discount is retrieved for ProducName: {coupon.ProductName}, Amount: {coupon.Amount}");

            var couponModel = _mapper.Map<CouponModel>(coupon);

            return couponModel;
        }

        public override async Task<CouponModel> CreateDiscount(
            CreateDiscountRequest request,
            ServerCallContext context
        )
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);

            await _discountRepository.CreateDiscount(coupon);

            _logger.LogInformation($"Discount is successfully created. ProductName: {coupon.ProductName}");

            var couponModel = _mapper.Map<CouponModel>(coupon);

            return couponModel;
        }

        public override async Task<CouponModel> UpdateDiscount(
            UpdateDiscountRequest request,
            ServerCallContext context
        )
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);

            await _discountRepository.UpdateDiscount(coupon);

            _logger.LogInformation($"Discount is successfully updated. ProductName: {coupon.ProductName}");

            var couponModel = _mapper.Map<CouponModel>(coupon);

            return couponModel;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(
            DeleteDiscountRequest request,
            ServerCallContext context
        )
        {
            await _discountRepository.DeleteDiscount(request.ProductName);

            _logger.LogInformation($"Discount is successfully deleted. ProductName: {request.ProductName}");

            var response = new DeleteDiscountResponse
            {
                Success = true
            };

            return response;
        }
    }
}
