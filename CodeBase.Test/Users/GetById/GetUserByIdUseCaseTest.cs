namespace CodeBase.Test.Users.GetById
{
    using AutoMapper;
    using Borders.Models;
    using Borders.Shared;
    using Borders.ViewModel;
    using Builders;
    using Moq;
    using Repositories.Users;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UseCases.Users.GetById;
    using Xunit;

    public class GetUserByIdUseCaseTest
    {
        private readonly GetUserByIdUseCase _getUserByIdUseCase;
        private readonly Mock<IMapper> _mapper = new();
        private readonly Mock<IUserRepository> _userRepository = new();

        public GetUserByIdUseCaseTest()
        {
            _getUserByIdUseCase = new GetUserByIdUseCase(_userRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetByIdAsync_WhenUserIsFound_ReturnUserAsync()
        {
            //Setup
            var user = new UserBuilder()
                .AddAge(10)
                .Build();

            _userRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(user);
            _mapper.Setup(x => x.Map<UserViewModel>(It.IsAny<User>())).Returns(new UserViewModel { Age = 10 });

            //Act
            var useCaseResponse = await _getUserByIdUseCase.Execute(Guid.Empty);

            //Assert 
            Assert.Equal(UseCaseResponseKind.OK, useCaseResponse.Status);
            Assert.NotNull(useCaseResponse.Result);
            Assert.IsAssignableFrom<UserViewModel>(useCaseResponse.Result);
            Assert.Equal(10, useCaseResponse.Result.Age);

            _userRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task GetByIdAsync_WhenUserIsNotFound_ReturnUserAsync()
        {
            //Setup
            _userRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((User)null);
            _mapper.Setup(x => x.Map<UserViewModel>(It.IsAny<User>())).Returns(null as UserViewModel);

            //Act
            var useCaseResponse = await _getUserByIdUseCase.Execute(Guid.Empty);

            //Assert 
            Assert.Equal(UseCaseResponseKind.NotFound, useCaseResponse.Status);
            Assert.Null(useCaseResponse.Result);

            _userRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
