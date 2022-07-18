using CodeBase.Borders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeBase.UseCases
{
    public interface IGetUserUseCase
    {
        Task<UserViewModel> GetUserAsync(Guid id);
        Task<IEnumerable<UserViewModel>> GetAllUserAsync();
    }
}
