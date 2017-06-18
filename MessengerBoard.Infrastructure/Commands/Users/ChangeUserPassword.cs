namespace MessengerBoard.Infrastructure.Commands.Users
{
    public class ChangeUserPassword : ICommand
    {
        public string NewPassword { get; set; }
        public string CurrentPassword { get; set; }
    }
}
