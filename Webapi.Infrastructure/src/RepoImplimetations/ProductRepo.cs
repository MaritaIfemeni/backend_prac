using Microsoft.EntityFrameworkCore;
using Webapi.Domain.src.Entities;
using Webapi.Domain.src.RepoInterfaces;
using Webapi.Infrastructure.src.Database;

namespace Webapi.Infrastructure.src.RepoImplimetations
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {

        private readonly DbSet<Product> _products;
        private readonly DatabaseContex _context;

        public ProductRepo(DatabaseContex dbContext) : base(dbContext)
        {
            _products = dbContext.Products;
            _context = dbContext;
        }

    }
}