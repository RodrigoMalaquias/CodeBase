using CodeBase.Borders;
using CodeBase.UseCases;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeBase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IGetUserUseCase _getUserUseCase;
        private readonly ILogger<UserController> _logger;
        private readonly IValidator<UserViewModel> _validator;
        private readonly IAddUserUseCase _addUserUseCase;

        public UserController(ILogger<UserController> logger, IGetUserUseCase getUserUseCase, IValidator<UserViewModel> validator, IAddUserUseCase addUserUseCase)
        {
            _logger = logger;
            _getUserUseCase = getUserUseCase;
            _validator = validator;
            _addUserUseCase = addUserUseCase;
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetAsync()
        {
            return await _getUserUseCase.GetAllUserAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserViewModel> GetByIdAsync(Guid id)
        {
            return await _getUserUseCase.GetUserAsync(id);
        }

        [HttpPost]
        public async Task AddUser(UserViewModel user)
        {
            try
            {
                await _validator.ValidateAndThrowAsync(user);

                await _addUserUseCase.AddUserAsync(user);
            }
            catch(ValidationException ex)
            {
                _logger.LogInformation($"Erro na validação do usuário - {ex}");
            }
        }

    }
}
