using AutoMapper;
using CodeBase.Borders.Models;
using CodeBase.Borders.ViewModel;
using CodeBase.Repositories.Products;
using CodeBase.Test.Builders;
using CodeBase.UseCases.Products.GetAll;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CodeBase.Test.Products
{
    public class GetAllProductsUseCaseTest
    {
        private readonly GetAllProductsUseCase _getAllProductsUseCase;
        private readonly Mock<IMapper> _mapper = new();
        private readonly Mock<IProductRepository> _productRepository = new();

        public GetAllProductsUseCaseTest()
        {
            _getAllProductsUseCase = new GetAllProductsUseCase(_mapper.Object, _productRepository.Object);
        }

        [Fact]
        public async Task GetAllProductsAsync_WhenProductsAreFound_ReturnProductsAsync()
        {
            //Setup
            IEnumerable<Product> products = new List<Product> 
            { 
                new ProductBuilder().AddName("Toy").AddPrice(1.5).Build(),
                new ProductBuilder().AddName("Ball").AddPrice(4).Build()
            };

            _productRepository.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(products);
            _mapper.Setup(x => x.Map<IEnumerable<ProductViewModel>>(products))
            .Returns(new List<ProductViewModel> 
            { 
                new ProductViewModel { Name = "Toy", Price = 1.5 }, 
                new ProductViewModel { Name = "Ball", Price = 4 } 
            });

            //Act
            var productUseCaseResponse = await _getAllProductsUseCase.Execute(true);

            //Assert 
            Assert.NotNull(productUseCaseResponse);
            Assert.IsType<List<ProductViewModel>>(productUseCaseResponse.Result);
        }
    }
}
