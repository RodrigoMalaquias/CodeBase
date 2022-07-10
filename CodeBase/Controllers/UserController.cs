using CodeBase.Model;
using CodeBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CodeBase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("{id}")]
        public User GetById(short id)
        {
            return _userRepository.Getbyid(id);
        }

    }
}
