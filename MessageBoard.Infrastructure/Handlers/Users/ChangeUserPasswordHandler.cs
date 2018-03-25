using System.Threading.Tasks;
using MessageBoard.Infrastructure.Commands;
using MessageBoard.Infrastructure.Commands.Users;

namespace MessageBoard.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        public async Task HandleAsync(ChangeUserPassword command)
        {
            await Task.CompletedTask;
        }
    }
}
