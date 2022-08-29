using CodeBase.Borders.Shared;
using CodeBase.Borders.ViewModel;
using System;

namespace CodeBase.UseCases.Products.GetById
{
    public interface IGetProductByIdUseCase : IUseCase<Guid, ProductViewModel>
    {
    }
}
