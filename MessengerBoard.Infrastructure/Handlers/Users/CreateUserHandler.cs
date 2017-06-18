using System.Threading.Tasks;
using MessengerBoard.Infrastructure.Commands;
using MessengerBoard.Infrastructure.Commands.Users;
using MessengerBoard.Infrastructure.Services;

namespace MessengerBoard.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(command.Email, command.Username, command.Password, "user");
        }
    }
}
