using System;
using System.Threading.Tasks;
using MessageBoard.Infrastructure.Commands;
using MessageBoard.Infrastructure.Commands.Users;
using MessageBoard.Infrastructure.Services;

namespace MessageBoard.Infrastructure.Handlers.Users
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
            await _userService.RegisterAsync(Guid.NewGuid(), command.Email, command.Username, command.Password, "user");
        }
    }
}
