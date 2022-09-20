using AutoMapper;
using CodeBase.Borders.Exceptions;
using CodeBase.Borders.Shared;
using CodeBase.Borders.ViewModel;
using CodeBase.Repositories.Products;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.UseCases.Products.GetById
{
    public class GetProductByIdUseCase : UseCaseBase<Guid, ProductViewModel>, IGetProductByIdUseCase
    {
        public override string DefaultErrorMessage => "";

        public override string DefaultSuccessMessage => "";

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductByIdUseCase(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        protected override async Task<SuccessResponse<ProductViewModel>> ExecuteUseCaseAsync(Guid request)
        {
            Log.Information("Getting product.\n  Request:{@request}", request);

            var product = await _productRepository.GetByIdAsync(request);

            if (product is null)
            {
                Log.Warning("Product with id:{@request} not found.", request);
                throw new NotFoundException("User not found.");
            }

            ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(product);
            return await OK(productViewModel);
        }
    }
}
