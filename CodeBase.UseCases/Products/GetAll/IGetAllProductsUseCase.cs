using CodeBase.Borders.Shared;
using CodeBase.Borders.ViewModel;
using System.Collections.Generic;

namespace CodeBase.UseCases.Products.GetAll
{
    public interface IGetAllProductsUseCase : IUseCase<bool, IEnumerable<ProductViewModel>>
    {
    }
}
