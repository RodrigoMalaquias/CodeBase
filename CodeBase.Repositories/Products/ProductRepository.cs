namespace CodeBase.Repositories.Products
{
    using CodeBase.Borders.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Product user, CancellationToken cancellationToken = default)
        {
            await _context.Product.AddAsync(user, cancellationToken: cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken: cancellationToken) > 0;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Product.ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Product.Where(i => i.Id == id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
