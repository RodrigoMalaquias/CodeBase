using CodeBase.Borders;
using CodeBase.Repositories;
using System;
using System.Threading.Tasks;

namespace CodeBase.UseCases
{
    public class AddUserUseCase : IAddUserUseCase
    {
        private readonly IUserRepository _userRepository;
        public AddUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public async Task AddUserAsync(UserViewModel user)
        {
           await _userRepository.AddAsync(user);
        }
    }
}
