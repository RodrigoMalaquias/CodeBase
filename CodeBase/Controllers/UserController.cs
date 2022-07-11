using CodeBase.Borders;
using CodeBase.UseCases;
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

        public UserController(ILogger<UserController> logger, IGetUserUseCase getUserUseCase)
        {
            _logger = logger;
            _getUserUseCase = getUserUseCase;
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

    }
}
