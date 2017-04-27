using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Salt { get; protected set; }
        public string Email { get; protected set; }
        public bool IsActive { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public string Fullname { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public User(string email, string username, string password, string salt)
        {
            Id = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            Username = username;
            Password = password;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }

        protected User()
        {
        }
    }
}
