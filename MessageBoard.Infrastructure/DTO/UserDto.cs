using System;

namespace MessageBoard.Infrastructure.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
