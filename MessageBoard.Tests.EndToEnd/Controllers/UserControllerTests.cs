using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using MessageBoard.Infrastructure.Commands.Users;
using MessageBoard.Infrastructure.DTO;
using Newtonsoft.Json;
using Xunit;

namespace MessageBoard.Tests.EndToEnd.Controllers
{
    public class UserControllerTests : ControllerTestsBase
    {
        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }

        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            const string email = "user1@email.com";
            var user = await GetUserAsync(email);
            user.Email.ShouldBeEquivalentTo(email);
        }

        [Fact]
        public async Task given_invalid_email_user_should_not_exist()
        {
            const string email = "user1000@email.com";
            var response = await Client.GetAsync($"users/{email}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var command = new CreateUser
            {
                Email = "test@email.com",
                Username = "test",
                Password = "secret"
            };
            var payload = GetPayload(command);
            var response = await Client.PostAsync("users", payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"users/{command.Email}");

            var user = await GetUserAsync(command.Email);
            user.Email.ShouldBeEquivalentTo(command.Email);
        }
    }
}