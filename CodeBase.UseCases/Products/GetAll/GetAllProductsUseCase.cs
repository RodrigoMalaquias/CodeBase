using AutoMapper;
using CodeBase.Borders.Exceptions;
using CodeBase.Borders.Shared;
using CodeBase.Borders.ViewModel;
using CodeBase.Repositories.Products;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeBase.UseCases.Products.GetAll
{
    public class GetAllProductsUseCase : UseCaseBase<bool, IEnumerable<ProductViewModel>>, IGetAllProductsUseCase
    {
        public override string DefaultErrorMessage => "";
        public override string DefaultSuccessMessage => "";

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetAllProductsUseCase(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        protected override async Task<SuccessResponse<IEnumerable<ProductViewModel>>> ExecuteUseCaseAsync(bool request)
        {
            Log.Information("Getting all products.");

            var products = await _productRepository.GetAllAsync();

            if (products is null)
            {
                Log.Warning("Products not found.");
                throw new NotFoundException("Products not found.");
            }

            var productsViewModel = _mapper.Map<IEnumerable<ProductViewModel>>(products);
            return await OK(productsViewModel);
        }
    }
}
