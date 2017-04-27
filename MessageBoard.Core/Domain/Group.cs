using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.Core.Domain
{
    public class Group
    {
        public Guid Id { get; protected set; }
        public User Admin { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public IEnumerable<User> Users { get; protected set; }
        public IEnumerable<Post> Posts { get; protected set; }
        
        public Group(string name, string description, User admin)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Admin = admin;
        }

        protected Group()
        {
        }
    }
}
