using AutoMapper;
using CodeBase.Borders;
using CodeBase.Borders.Model;
using CodeBase.Repositories;
using System;
using System.Threading.Tasks;

namespace CodeBase.UseCases
{
    public class AddUserUseCase : IAddUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AddUserUseCase(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper;
        }
        public async Task AddUserAsync(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);
            await _userRepository.AddAsync(user);
        }
    }
}
