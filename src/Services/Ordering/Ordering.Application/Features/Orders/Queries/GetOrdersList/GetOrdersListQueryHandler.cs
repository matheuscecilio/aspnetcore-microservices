using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersListQueryHandler(
            IOrderRepository orderRepository, 
            IMapper mapper
        )
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrdersDto>> Handle(
            GetOrdersListQuery request, 
            CancellationToken cancellationToken
        )
        {
            var orders = await _orderRepository.GetOrdersByUserName(
                request.UserName
            );

            var ordersDto = _mapper.Map<List<OrdersDto>>(orders);

            return ordersDto;
        }
    }
}
