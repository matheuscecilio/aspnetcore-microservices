﻿using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities;
using Ordering.Infrasructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrasructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
            => await _dbContext.Orders
                .Where(x => x.UserName == userName)
                .ToListAsync();
    }
}
