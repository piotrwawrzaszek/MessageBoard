using System;
using System.Collections.Generic;
using System.Text;
using MessageBoard.Core.Domain;

namespace MessageBoard.Infrastructure.DTO
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public Group Group { get; set; }
        public User Author { get; set; }
        public bool IsActive { get; set; }
        public string Content { get; set; }
        public Post PostParent { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}