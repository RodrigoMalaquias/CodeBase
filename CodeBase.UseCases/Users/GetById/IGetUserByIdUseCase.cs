namespace CodeBase.UseCases.Users.GetById
{
    using Borders.Shared;
    using Borders.ViewModel;
    using System;

    public interface IGetUserByIdUseCase : IUseCase<Guid, UserViewModel>
    {
    }
}
