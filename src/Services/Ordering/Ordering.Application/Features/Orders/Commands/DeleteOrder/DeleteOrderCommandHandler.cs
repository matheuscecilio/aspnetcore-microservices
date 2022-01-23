using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exceptions;
using Ordering.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        public DeleteOrderCommandHandler(
            IOrderRepository orderRepository,
            ILogger<DeleteOrderCommandHandler> logger, 
            IMapper mapper
        )
        {
            _orderRepository = orderRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(
            DeleteOrderCommand request, 
            CancellationToken cancellationToken
        )
        {
            var orderToDelete = await _orderRepository.GetByIdAsync(
                request.Id
            );

            if (orderToDelete is null)
            {
                _logger.LogError("Order not exist on database.");
                
                throw new NotFoundException(
                    nameof(Order), 
                    request.Id
                );
            }

            await _orderRepository.DeleteAsync(
                orderToDelete
            );

            _logger.LogInformation($"Order {orderToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
