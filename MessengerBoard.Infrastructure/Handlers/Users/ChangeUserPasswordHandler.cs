using System.Threading.Tasks;
using MessengerBoard.Infrastructure.Commands;
using MessengerBoard.Infrastructure.Commands.Users;

namespace MessengerBoard.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        public async Task HandleAsync(ChangeUserPassword command)
        {
            await Task.CompletedTask;
        }
    }
}
