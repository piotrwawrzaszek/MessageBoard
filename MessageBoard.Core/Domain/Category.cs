using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.Core.Domain
{
    public class Category
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public IEnumerable<Post> Posts { get; protected set; }

        public Category(string name, string description)
        {
            Id = new Guid();
            Name = name;
            Description = description;
        }

        protected Category()
        {
        }
    }
}
