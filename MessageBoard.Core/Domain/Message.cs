using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.Core.Domain
{
    public class Message
    {
        public Guid Id { get; protected set; }
        public User Author { get; protected set; }
        public string Content { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public Conversation Conversation { get; protected set; }

        public Message(string content, User author, Conversation conversation)
        {
            Id = Guid.NewGuid();
            Content = content;
            Author = author;
            Conversation = conversation;
            CreatedAt = DateTime.UtcNow;
        }

        protected Message()
        {
        }
    }
}
