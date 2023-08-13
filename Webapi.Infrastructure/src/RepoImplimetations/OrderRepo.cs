using Microsoft.EntityFrameworkCore;
using Webapi.Domain.src.Entities;
using Webapi.Domain.src.RepoInterfaces;
using Webapi.Infrastructure.src.Database;

namespace Webapi.Infrastructure.src.RepoImplimetations
{


    public class OrderRepo
    {
        private readonly DbSet<Order> _orders;
        private readonly DatabaseContex _context;

        public OrderRepo(DatabaseContex dbContext)
        {
            _orders = dbContext.Orders;
            _context = dbContext;

        }
    }
}