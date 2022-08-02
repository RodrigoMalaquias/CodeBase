namespace CodeBase.Controllers
{
    using CodeBase.Borders.ViewModel;
    using CodeBase.Converters;
    using CodeBase.Shared.Models;
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
        public ProductController(IActionResultConverter actionResultConverter, IGetAllProductsUseCase getAllProductsUseCase)
        {
            _actionResultConverter = actionResultConverter ?? throw new ArgumentNullException(nameof(actionResultConverter));
            _getAllProductsUseCase = getAllProductsUseCase ?? throw new ArgumentNullException(nameof(getAllProductsUseCase));
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
    }
}
