using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.Core.Domain
{
    public class Conversation
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public IEnumerable<User> Users { get; protected set; }
        public IEnumerable<Message> Messages { get; protected set; }

        public Conversation(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        protected Conversation()
        {
        }
    }
}
