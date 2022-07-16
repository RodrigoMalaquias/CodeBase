namespace CodeBase.Test
{
    using AutoMapper;
    using CodeBase.Borders;
    using CodeBase.Borders.Model;
    using CodeBase.Repositories;
    using CodeBase.Test.Builders;
    using CodeBase.UseCases;
    using Moq;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class GetUserUseCaseTest
    {
        private readonly GetUserUseCase _getUserUseCase;
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly Mock<IUserRepository> userRepository = new Mock<IUserRepository>();

        public GetUserUseCaseTest()
        {
            _getUserUseCase = new GetUserUseCase(userRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetUserAsync_WhenUserIsFound_ReturnUserAsync()
        {
            //Setup
            var user = new UserBuilder()
                .AddAge(10)
                .Build();

            userRepository.Setup(x => x.GetbyidAsync(It.IsAny<Guid>())).ReturnsAsync(user);
            _mapper.Setup(x => x.Map<UserViewModel>(It.IsAny<User>())).Returns(new UserViewModel { Age = 10});

            //Act
            var userAct = await _getUserUseCase.GetUserAsync(Guid.Empty);

            //Assert 
            Assert.IsAssignableFrom(typeof(UserViewModel), userAct);
            Assert.NotNull(userAct.Age);
            userRepository.Verify(x => x.GetbyidAsync(It.IsAny<Guid>()), Times.Once());

        }
    }
}
