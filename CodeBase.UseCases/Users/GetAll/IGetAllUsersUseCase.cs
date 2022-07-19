namespace CodeBase.UseCases.Users.GetAll
{
    using Borders.Shared;
    using Borders.ViewModel;
    using System.Collections.Generic;

    public interface IGetAllUsersUseCase : IUseCase<bool, IEnumerable<UserViewModel>>
    {
    }
}
