using AutoMapper;
using MessageBoard.Core.Domain;
using MessageBoard.Core.Repositories;
using MessengerBoard.Infrastructure.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace MessageBoard.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.RegisterAsync("user@email.com", "user", "secret", "user");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
