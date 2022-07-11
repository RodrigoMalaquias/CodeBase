using CodeBase.Borders;
using CodeBase.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeBase.UseCases
{
    public class GetUserUseCase : IGetUserUseCase
    {
        private readonly IUserRepository _userRepository;
        public GetUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUserAsync()
        {
           return await _userRepository.GetAllAsync();
        }

        public async Task<UserViewModel> GetUserAsync(Guid id)
        {
           return await  _userRepository.GetbyidAsync(id);
        }
    }
}
