using AutoMapper;
using CodeBase.Borders.Models;
using CodeBase.Borders.Shared;
using CodeBase.Borders.ViewModel;
using CodeBase.Repositories.Products;
using System;
using System.Threading.Tasks;

namespace CodeBase.UseCases.Products.Add
{
    class AddProductUseCase : UseCaseBase<ProductViewModel, bool>, IAddProductUseCase
    {
        public override string DefaultErrorMessage => "";

        public override string DefaultSuccessMessage => "";

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AddProductUseCase(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
        }

        protected override async Task<SuccessResponse<bool>> ExecuteUseCaseAsync(ProductViewModel request)
        {
            var product = _mapper.Map<Product>(request);
            var added = await _productRepository.AddAsync(product);
            return await Created(added);
        }
    }
}
