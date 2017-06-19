using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace MessageBoard.Core.Domain
{
    public class User
    {
        private ISet<Post> _upvotedPosts = new HashSet<Post>();
        private ISet<Post> _downvotedPosts = new HashSet<Post>();
        private ISet<User> _friends = new HashSet<User>();

        public Guid Id { get; protected set; }
        public string Salt { get; protected set; }
        public string Role { get; protected set; }
        public string Email { get; protected set; }
        public bool IsActive { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public IEnumerable<User> Friends
        {
            get { return _friends; }
            protected set { _friends = new HashSet<User>(value); }
        }

        public IEnumerable<Post> UpvotedPosts
        {
            get { return _upvotedPosts; }
            protected set { _upvotedPosts = new HashSet<Post>(value); } 
            
        }
        public IEnumerable<Post> DownvotedPosts {
            get { return _downvotedPosts; }
            protected set { _downvotedPosts = new HashSet<Post>(value); }
        }

        public User(Guid id, string email, string username, string password, string salt, string role)
        {
            Id = id;
            SetEmail(email);
            SetUsername(username);
            SetPassword(password, salt);
            SetRole(role);
            Activate();
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
            var regex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
            if (Username == username)
            {
                return;
            }
            if (!regex.IsMatch(username))
            {
                throw new Exception("Username is invalid.");
            }
            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("Username can not be empty.");
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
                throw new Exception("Email can not be empty.");
            }
            if (!new EmailAddressAttribute().IsValid(email))
            {    
                throw new Exception("Email is invalid.");
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

        public void SetPassword(string password, string salt)
        {
            if (Password == password)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty");
            }
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new Exception("Salt can not be empty.");
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
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Activate()
        {
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddUpvotedPost(Post post)
        {
            var upvotedPost = UpvotedPosts.SingleOrDefault(x => x.Id == post.Id);
            if (upvotedPost != null)
            {
                throw new Exception($"User: {Username} already upvoted post: {post.Content.Substring(0,20)}...");
            }
            _upvotedPosts.Add(post);
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveUpvotingUser(Post post)
        {
            var upvotedPost = UpvotedPosts.SingleOrDefault(x => x.Id == post.Id);
            if (upvotedPost == null)
            {
                throw new Exception($"Post: {post.Content.Substring(0,20)}... for user: {Username} not found.");
            }
            _upvotedPosts.Remove(post);
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddDownvotedPost(Post post)
        {
            var downvotedPost = DownvotedPosts.SingleOrDefault(x => x.Id == post.Id);
            if (downvotedPost != null)
            {
                throw new Exception($"User: {Username} already downvoted post: {post.Content.Substring(0, 20)}...");
            }
            _downvotedPosts.Add(post);
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveDownvotingUser(Post post)
        {
            var downvotedPost = DownvotedPosts.SingleOrDefault(x => x.Id == post.Id);
            if (downvotedPost == null)
            {
                throw new Exception($"Post: {post.Content.Substring(0, 20)}... for user: {Username} not found.");
            }
            _downvotedPosts.Remove(post);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}