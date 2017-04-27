using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.Core.Domain
{
    public class Post
    {
        public Guid Id { get; protected set; }
        public Group Group { get; protected set; }
        public User Author { get; protected set; }
        public string Content { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public Category Category { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public IEnumerable<User> UpvotingUsers { get; protected set; }
        public IEnumerable<User> DownvotingUsers { get; protected set; }

        public Post(Group group, User author, string content, Category category)
        {
            Id = Guid.NewGuid();
            Group = group;
            Author = author;
            Content = content;
            Category = category;
            IsDeleted = false;
            CreatedAt = DateTime.UtcNow;
        }

        protected Post()
        {
        }
    }
}
