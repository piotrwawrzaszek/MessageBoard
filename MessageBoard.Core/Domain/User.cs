using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace MessageBoard.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Salt { get; protected set; }
        public string Role { get; protected set; }
        public string Email { get; protected set; }
        public bool IsActive { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public string Fullname { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public User(string email, string username, string password, string salt, string role)
        {
            Id = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            Username = username;
            Password = password;
            Salt = salt;
            Role = role;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        protected User()
        {
        }

        public void SetUserId(string userId)
        {
        }

        public void SetUsername(string username)
        {
            //var regex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
            if (Username == username)
            {
                return;
            }
            //if (!regex.IsMatch(username))
            //{
            //    throw new Exception("Username is invalid");
            //}
            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("Username can not be empty");
            }
            Username = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (Email == email)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email can not be empty");
            }
            if (!IsMailValid(email))
            {
                throw new Exception("Email is invalid");
            }
            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetRole(string role)
        {
            if (Role == role)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new Exception("Role can not be empty");
            }
            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            if (Password == password)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty");
            }
            if (password.Length < 4)
            {
                throw new Exception("Password must contain at least 4 characters.");
            }
            if (password.Length > 20)
            {
                throw new Exception("Password can not contain more than 20 characters.");
            }
            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }

        private static bool IsMailValid(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}