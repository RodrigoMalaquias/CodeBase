using AutoMapper;
using CodeBase.Borders.Models;
using CodeBase.Borders.ViewModel;
using CodeBase.Repositories.Users;
using CodeBase.Test.Builders;
using CodeBase.UseCases.Users.GetAll;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CodeBase.Test.Users.GetAll
{
    public class GetAllUsersUseCaseTest
    {
        private readonly GetAllUsersUseCase _getAllUsersUseCase;
        private readonly Mock<IUserRepository> _userRepository = new();
        private readonly Mock<IMapper> _mapper = new();

        public GetAllUsersUseCaseTest()
        {
            _getAllUsersUseCase = new GetAllUsersUseCase(_userRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetAllUsersAsync_WhenUsersAreFound_ReturnUsersAsync()
        {
            IEnumerable<User> products = new List<User>
            {
                new UserBuilder().AddName("Alisson").AddAge(23).Build(),
                new UserBuilder().AddName("Diego").AddAge(26).Build()
            };

            _userRepository.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(products);
            _mapper.Setup(x => x.Map<IEnumerable<UserViewModel>>(products))
            .Returns(new List<UserViewModel>
            {
                new UserViewModel { Name = "Alisson", Age = 23 },
                new UserViewModel { Name = "Diego", Age = 26 }
            });

            var productUseCaseResponse = await _getAllUsersUseCase.Execute(true);

            Assert.NotNull(productUseCaseResponse);
            Assert.IsType<List<UserViewModel>>(productUseCaseResponse.Result);
        }
    }

}
