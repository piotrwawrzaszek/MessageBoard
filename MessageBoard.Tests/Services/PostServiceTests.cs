using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MessageBoard.Core.Domain;
using MessageBoard.Core.Repositories;
using MessageBoard.Infrastructure.Services;
using Moq;
using Xunit;

namespace MessageBoard.Tests.Services
{
    public class PostServiceTests
    {
        [Fact]
        public async Task add_async_should_invoke_add_async_on_repository()
        {
            var postRepositoryMock = new Mock<IPostRepository>();
            var categoryProvider = new Mock<ICategoryProvider>();
            var encrypterMock = new Mock<IEncrypter>();
            var mapperMock = new Mock<IMapper>();

            var postService = new PostService(postRepositoryMock.Object, mapperMock.Object,
                categoryProvider.Object, encrypterMock.Object);
            var admin = new User(Guid.NewGuid(), "test1@email.com", "test1", "secret", "salt", "user");
            var group = new Group("test_group", "test group", admin);

            var category = Category.Create("Movies", "Horror", "Here’s Johnny!");
            await postService.AddAsync(Guid.NewGuid(), group, admin, "Testing...", category);
            postRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Post>()), Times.Once);
        }
    }
}