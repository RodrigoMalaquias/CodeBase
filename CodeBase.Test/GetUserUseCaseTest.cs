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
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class GetUserUseCaseTest
    {
        private readonly GetUserUseCase _getUserUseCase;
        private readonly Mock<IMapper> _mapper = new();
        private readonly Mock<IUserRepository> userRepository = new();

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
            _mapper.Setup(x => x.Map<UserViewModel>(It.IsAny<User>())).Returns(new UserViewModel { Age = 10 });

            //Act
            var userAct = await _getUserUseCase.GetUserAsync(Guid.Empty);

            //Assert 
            Assert.IsAssignableFrom(typeof(UserViewModel), userAct);
            Assert.NotNull(userAct.Age);
            userRepository.Verify(x => x.GetbyidAsync(It.IsAny<Guid>()), Times.Once());

        }

        [Fact]
        public async Task GetUserAsync_WhenUserIsNotFound_ReturnUserAsync()
        {
            //Setup
            userRepository.Setup(x => x.GetbyidAsync(It.IsAny<Guid>())).ReturnsAsync(null as User);
            _mapper.Setup(x => x.Map<UserViewModel>(It.IsAny<User>())).Returns(null as UserViewModel);

            //Act
            var userAct = await _getUserUseCase.GetUserAsync(Guid.Empty);

            //Assert 
            Assert.Null(userAct);
        }

        [Fact]
        public async Task GetUsersAsync_WhenUsersAreFound_ReturnUsersAsync()
        {
            //Setup
            var firstUser = new UserBuilder()
                .AddAge(10)
                .Build();
            var secondUser = new UserBuilder()
                .AddAge(22)
                .AddName("Rodrigo")
                .Build();

            IEnumerable<User> users = new List<User> { firstUser, secondUser };

            userRepository.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(users);
            _mapper.Setup(x => x.Map<IEnumerable<UserViewModel>>(It.IsAny<IEnumerable<User>>()))
            .Returns(new List<UserViewModel>
            {
                new UserViewModel { Age = 10 },
                new UserViewModel { Age = 22, Name = "Rodrigo" },
            });

            //Act
            var usersAct = await _getUserUseCase.GetAllUserAsync();

            //Assert 
            Assert.IsAssignableFrom(typeof(IEnumerable<UserViewModel>), usersAct);
        }

        [Fact]
        public async Task GetUsersAsync_WhenUsersAreNotFound_ReturnUsersAsync()
        {
            //Setup
            userRepository.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(Enumerable.Empty<User>());
            _mapper.Setup(x => x.Map<IEnumerable<UserViewModel>>(It.IsAny<IEnumerable<User>>())).Returns(Enumerable.Empty<UserViewModel>());

            //Act
            var usersAct = await _getUserUseCase.GetAllUserAsync();

            //Assert 
            Assert.IsAssignableFrom(typeof(IEnumerable<UserViewModel>), usersAct);
            Assert.Empty(usersAct);
        }
    }
}
