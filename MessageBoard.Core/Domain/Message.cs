using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageBoard.Core.Domain
{
    public class Message
    {
        private ISet<User> _viewerList = new HashSet<User>();

        public Guid Id { get; protected set; }
        public User Author { get; protected set; }
        public string Content { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public Conversation Conversation { get; protected set; }

        public IEnumerable<User> ViewerList 
        {
            get { return _viewerList; }
            protected set { _viewerList = new HashSet<User>(value); }
        }

        public Message(string content, User author, Conversation conversation)
        {
            Id = Guid.NewGuid();
            SetContent(content);
            Author = author;
            Conversation = conversation;
            CreatedAt = DateTime.UtcNow;
        }

        protected Message()
        {
        }

        public void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new Exception("Message content can not be empty.");
            }
            Content = content;
        }

        public void AddViewer(User user)
        {
            var viewer = ViewerList.SingleOrDefault(x => x.Id == user.Id);
            if (viewer != null)
            {
                throw new Exception($"User: {user.Username} already viewed message: {Content.Substring(0, 10)}...");
            }
            _viewerList.Add(user);
        }

        public void RemoveViewer(User user)
        {
            var viewer = ViewerList.SingleOrDefault(x => x.Id == user.Id);
            if (viewer == null)
            {
                throw new Exception($"User: {user.Username} for message: {Content.Substring(0, 10)}... not found.");
            }
            _viewerList.Remove(user);
        }
    }
}
