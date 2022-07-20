namespace CodeBase.Controllers
{
    using Borders.ViewModel;
    using Converters;
    using Microsoft.AspNetCore.Mvc;
    using Shared.Models;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using UseCases.Users.Add;
    using UseCases.Users.GetAll;
    using UseCases.Users.GetById;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IActionResultConverter _actionResultConverter;
        private readonly IGetUserByIdUseCase _getUserByIdUseCase;
        private readonly IGetAllUsersUseCase _getAllUsersUseCase;
        private readonly IAddUserUseCase _addUserUseCase;

        public UserController(IActionResultConverter actionResultConverter,
            IGetUserByIdUseCase getUserByIdUseCase,
            IGetAllUsersUseCase getAllUsersUseCase,
            IAddUserUseCase addUserUseCase)
        {
            _actionResultConverter = actionResultConverter ?? throw new ArgumentNullException(nameof(actionResultConverter));
            _getUserByIdUseCase = getUserByIdUseCase ?? throw new ArgumentNullException(nameof(getUserByIdUseCase));
            _getAllUsersUseCase = getAllUsersUseCase ?? throw new ArgumentNullException(nameof(getAllUsersUseCase));
            _addUserUseCase = addUserUseCase ?? throw new ArgumentNullException(nameof(addUserUseCase));
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<UserViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(IEnumerable<ErrorMessage>))]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _getAllUsersUseCase.Execute(true);
            return _actionResultConverter.Convert(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(IEnumerable<ErrorMessage>))]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _getUserByIdUseCase.Execute(id);
            return _actionResultConverter.Convert(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IEnumerable<ErrorMessage>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(IEnumerable<ErrorMessage>))]
        public async Task<IActionResult> CreateUser([FromBody] UserViewModel request)
        {
            var result = await _addUserUseCase.Execute(request);
            return _actionResultConverter.Convert(result);
        }
    }
}
