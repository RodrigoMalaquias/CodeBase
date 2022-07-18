using AutoMapper;
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
        private readonly IMapper _mapper;
        public GetUserUseCase(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUserAsync()
        {
           var users = await _userRepository.GetAllUsersAsync();
           return _mapper.Map<IEnumerable<UserViewModel>>(users);
        }

        public async Task<UserViewModel> GetUserAsync(Guid id)
        {
           var user = await  _userRepository.GetbyidAsync(id);
           return _mapper.Map<UserViewModel>(user);
        }
    }
}
