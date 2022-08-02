namespace CodeBase.Repositories.Products
{
    using CodeBase.Borders.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Product.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
