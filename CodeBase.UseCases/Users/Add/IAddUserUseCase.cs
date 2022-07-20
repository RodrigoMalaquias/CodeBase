namespace CodeBase.UseCases.Users.Add
{
    using Borders.Shared;
    using Borders.ViewModel;
    using System;

    public interface IAddUserUseCase : IUseCase<UserViewModel, bool>
    {
    }
}
