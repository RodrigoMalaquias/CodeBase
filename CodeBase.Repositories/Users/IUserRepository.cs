namespace CodeBase.Repositories.Users
{
    using Borders.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync();
        Task<UserViewModel> GetByIdAsync(Guid id);
    }
}
