namespace CodeBase.UseCases.Users.GetById
{
    using AutoMapper;
    using Borders.Exceptions;
    using Borders.Shared;
    using Borders.ViewModel;
    using CodeBase.Repositories.Users;
    using Serilog;
    using System;
    using System.Threading.Tasks;

    public class GetUserByIdUseCase : UseCaseBase<Guid, UserViewModel>, IGetUserByIdUseCase
    {
        public override string DefaultErrorMessage => "";
        public override string DefaultSuccessMessage => "";

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserByIdUseCase(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        protected override async Task<SuccessResponse<UserViewModel>> ExecuteUseCaseAsync(Guid request)
        {
            Log.Information("Getting user.\n  Request:{@request}", request);

            var user = await _userRepository.GetByIdAsync(request);

            if (user is null)
            {
                Log.Warning("User with id:{@request} not found.", request);
                throw new NotFoundException("User not found.");
            }

            var userViewModel = _mapper.Map<UserViewModel>(user);
            return await OK(userViewModel);
        }
    }
}
