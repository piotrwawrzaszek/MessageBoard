using System;

namespace MessageBoard.Infrastructure.Commands.Posts
{
    public class AddPost : ICommand
    {
        public string Email { get; set; }
        public string CategoryType { get; set; }
        public string CategoryName { get; set; }
        public string Content { get; set; }
        public Guid GroupId{ get; set; }
    }
}

