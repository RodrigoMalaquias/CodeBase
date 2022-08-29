namespace CodeBase.Controllers
{
    using CodeBase.Borders.ViewModel;
    using CodeBase.Converters;
    using CodeBase.Shared.Models;
    using CodeBase.UseCases.Products.Add;
    using CodeBase.UseCases.Products.GetById;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using UseCases.Products.GetAll;

    [ApiController]
    [Route("[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly IActionResultConverter _actionResultConverter;
        private readonly IGetAllProductsUseCase _getAllProductsUseCase;
        private readonly IGetProductByIdUseCase _getProductByIdUseCase;
        private readonly IAddProductUseCase _addProductByIdUseCase;
        public ProductController(IActionResultConverter actionResultConverter, 
            IGetAllProductsUseCase getAllProductsUseCase, IGetProductByIdUseCase getProductByIdUseCase,
            IAddProductUseCase addProductByIdUseCase)
        {
            _actionResultConverter = actionResultConverter ?? throw new ArgumentNullException(nameof(actionResultConverter));
            _getAllProductsUseCase = getAllProductsUseCase ?? throw new ArgumentNullException(nameof(getAllProductsUseCase));
            _getProductByIdUseCase = getProductByIdUseCase ?? throw new ArgumentNullException(nameof(getProductByIdUseCase));
            _addProductByIdUseCase = addProductByIdUseCase ?? throw new ArgumentNullException(nameof(addProductByIdUseCase));
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ProductViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(IEnumerable<ErrorMessage>))]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _getAllProductsUseCase.Execute(true);
            return _actionResultConverter.Convert(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProductViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(IEnumerable<ErrorMessage>))]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _getProductByIdUseCase.Execute(id);
            return _actionResultConverter.Convert(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(IEnumerable<ErrorMessage>))]
        public async Task<IActionResult> CreateProduct([FromBody] ProductViewModel product)
        {
            var result = await _addProductByIdUseCase.Execute(product);
            return _actionResultConverter.Convert(result);
        }
    }
}
