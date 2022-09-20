namespace CodeBase.Repositories.Products
{
    using CodeBase.Borders.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> AddAsync(Product user, CancellationToken cancellationToken = default);
    }
}
