using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageBoard.Core.Domain
{
    public class Group
    {
        private ISet<User> _members = new HashSet<User>();
        private ISet<Post> _posts = new HashSet<Post>();

        public Guid Id { get; protected set; }
        public User Admin { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public IEnumerable<User> Members
        {
            get { return _members; }
            protected set { _members = new HashSet<User>(value); }
        }

        public IEnumerable<Post> Posts
        {
            get { return _posts; }
            protected set { _posts = new HashSet<Post>(value); }
        }
        
        public Group(string name, string description, User admin)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetDescription(description);
            SetAdmin(admin);
            CreatedAt = DateTime.UtcNow;
        }

        protected Group()
        {
        }

        public void SetAdmin(User admin)
        {
            Admin = admin;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Group name can not be empty");
            }
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Group description can not be empty");
            }
            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddMember(User user)
        {
            var member = Members.SingleOrDefault(x => x.Id == user.Id);
            if (member != null)
            {
                throw new Exception($"User: {user.Username} already is a member of the group: {Name}.");
            }
            _members.Add(user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveMember(User user)
        {
            var member = Members.SingleOrDefault(x => x.Id == user.Id);
            if (member == null)
            {
                throw new Exception($"User: {user.Username} for group: {Name} not found.");
            }
            _members.Remove(user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddPost(Post post)
        {
            var msg = Posts.SingleOrDefault(x => x.Id == post.Id);
            if (msg != null)
            {
                throw new Exception($"Post: {msg.Content.Substring(0,20)} was send to the group: {Name}.");
            }
            _posts.Add(post);
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemovePost(Post post)
        {
            var msg = Posts.SingleOrDefault(x => x.Id == post.Id);
            if (msg == null)
            {
                throw new Exception($"Post: {post.Content.Substring(0, 20)} for group: {Name} not found.");
            }
            _posts.Remove(post);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
