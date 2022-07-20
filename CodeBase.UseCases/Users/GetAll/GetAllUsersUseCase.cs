namespace CodeBase.UseCases.Users.GetAll
{
    using AutoMapper;
    using Borders.Exceptions;
    using Borders.Shared;
    using Borders.ViewModel;
    using Repositories.Users;
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class GetAllUsersUseCase : UseCaseBase<bool, IEnumerable<UserViewModel>>, IGetAllUsersUseCase
    {
        public override string DefaultErrorMessage => "";
        public override string DefaultSuccessMessage => "";
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetAllUsersUseCase(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        protected override async Task<SuccessResponse<IEnumerable<UserViewModel>>> ExecuteUseCaseAsync(bool request)
        {
            Log.Information("Getting all users.");

            IEnumerable<UserViewModel> users = await _userRepository.GetAllAsync();

            if (users is null)
            {
                Log.Warning("Users not found.");
                throw new NotFoundException("Users not found.");
            }

            IEnumerable<UserViewModel> usersViewModel = _mapper.Map<IEnumerable<UserViewModel>>(users);
            return await OK(usersViewModel);
        }
    }
}
