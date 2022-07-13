using CodeBase.Borders;
using System;
using System.Threading.Tasks;

namespace CodeBase.UseCases
{
    public interface IAddUserUseCase
    {
        Task AddUserAsync(UserViewModel user);
    }
}
