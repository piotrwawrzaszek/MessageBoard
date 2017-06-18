using System;

namespace MessengerBoard.Infrastructure.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
