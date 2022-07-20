namespace CodeBase.UseCases.Users.Add
{
    using AutoMapper;
    using Borders.Models;
    using Borders.Shared;
    using Borders.ViewModel;
    using Repositories.Users;
    using System;
    using System.Threading.Tasks;

    public class AddUserUseCase : UseCaseBase<UserViewModel, bool>, IAddUserUseCase
    {
        public override string DefaultErrorMessage => "";
        public override string DefaultSuccessMessage => "";

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AddUserUseCase(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper;
        }

        protected override async Task<SuccessResponse<bool>> ExecuteUseCaseAsync(UserViewModel request)
        {
            var user = _mapper.Map<User>(request);
            var added = await _userRepository.AddAsync(user);
            return await Created(added);
        }
    }
}
