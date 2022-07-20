namespace CodeBase.Repositories.Users
{
    using Borders.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> AddAsync(User user, CancellationToken cancellationToken = default);
    }
}
