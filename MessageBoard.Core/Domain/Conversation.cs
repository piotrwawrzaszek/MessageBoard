using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageBoard.Core.Domain
{
    public class Conversation
    {
        private ISet<User> _members = new HashSet<User>();
        private ISet<Message> _messages = new HashSet<Message>();

        public Guid Id { get; protected set; }
        public User Admin { get; protected set; }
        public string Name { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public IEnumerable<User> Members
        {
            get { return _members; }
            protected set { _members = new HashSet<User>(value); }
        }

        public IEnumerable<Message> Messages
        {
            get { return _messages; }
            protected set { _messages = new HashSet<Message>(value); }
        }

        public Conversation(User creator, string name)
        {
            Id = Guid.NewGuid();
            SetAdmin(creator);
            SetName(name);
            CreatedAt = DateTime.UtcNow;
        }

        protected Conversation()
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
                throw new Exception("Conversation name can not be empty.");
            }
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddMember(User user)
        {
            var member = Members.SingleOrDefault(x => x.Id == user.Id);
            if (member != null)
            {
                throw new Exception($"User: {user.Username} is a member of the conversation: {Name}.");
            }
            _members.Add(user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveMember(User user)
        {
            var member = Members.SingleOrDefault(x => x.Id == user.Id);
            if (member == null)
            {
                throw new Exception($"User: {user.Username} is not a member of the conversation: {Name}.");
            }
            _members.Remove(user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddMessage(Message message)
        {
            var msg = Messages.SingleOrDefault(x => x.Id == message.Id);
            if (msg != null)
            {
                throw new Exception($"Message: {message.Content} already exists in the conversation.");
            }
            _messages.Add(message);
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveMessage(Message message)
        {
            var msg = Messages.SingleOrDefault(x => x.Id == message.Id);
            if (msg == null)
            {
                throw new Exception($"Message: {message.Content} not found.");
            }
            _messages.Remove(message);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
