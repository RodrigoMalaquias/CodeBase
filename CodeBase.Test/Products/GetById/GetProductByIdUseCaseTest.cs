using AutoMapper;
using CodeBase.Borders.Models;
using CodeBase.Borders.Shared;
using CodeBase.Borders.ViewModel;
using CodeBase.Repositories.Products;
using CodeBase.Test.Builders;
using CodeBase.UseCases.Products.GetById;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CodeBase.Test.Products.GetById
{
    public class GetProductByIdUseCaseTest
    {
        private readonly GetProductByIdUseCase _getProductByIdUseCase;
        private readonly Mock<IMapper> _mapper = new();
        private readonly Mock<IProductRepository> _productRepository = new();

        public GetProductByIdUseCaseTest()
        {
            _getProductByIdUseCase = new GetProductByIdUseCase(_mapper.Object, _productRepository.Object);
        }

        [Fact]
        public async Task GetByIdAsync_WhenProductIsFound_ReturnProductAsync()
        {
            var product = new ProductBuilder()
                .AddName("Toy")
                .AddPrice(0.5)
                .Build();

            _productRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(product);
            _mapper.Setup(x => x.Map<ProductViewModel>(It.IsAny<Product>())).Returns(new ProductViewModel { Name = "Toy", Price = 0.5});

            var useCaseResponse = await _getProductByIdUseCase.Execute(product.Id);

            Assert.NotNull(useCaseResponse.Result);
            Assert.Equal(product.Name, useCaseResponse.Result.Name);
            Assert.Equal(product.Price, useCaseResponse.Result.Price);
            Assert.Equal(UseCaseResponseKind.OK, useCaseResponse.Status);
            Assert.IsAssignableFrom<UserViewModel>(useCaseResponse.Result);

            _productRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task GetByIdAsync_WhenProductIsNotFound_ReturnProductAsync()
        {
            _productRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(null as Product);
            _mapper.Setup(x => x.Map<ProductViewModel>(It.IsAny<Product>())).Returns(null as ProductViewModel);

            var useCaseResponse = await _getProductByIdUseCase.Execute(Guid.Empty);

            Assert.NotNull(useCaseResponse);
            Assert.Equal(UseCaseResponseKind.NotFound, useCaseResponse.Status);

            _productRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
