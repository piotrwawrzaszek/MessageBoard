using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageBoard.Core.Domain
{
    public class Post
    {
        private static ISet<Post> _postChildren = new HashSet<Post>();
        private static ISet<User> _upvotingUsers = new HashSet<User>();
        private static ISet<User> _downvotingUsers = new HashSet<User>();

        
        public Guid Id { get; protected set; }
        public Group Group { get; protected set; }
        public User Author { get; protected set; }
        public bool IsActive { get; protected set; }
        public string Content { get; protected set; }
        public Post PostParent { get; protected set; }
        public Category Category { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public IEnumerable<User> UpvotingUsers
        {
            get { return _upvotingUsers; }
            protected set { _upvotingUsers = new HashSet<User>(value); } 
        }

        public IEnumerable<User> DownvotingUsers
        {
            get { return _downvotingUsers; }
            protected set { _downvotingUsers = new HashSet<User>(value); }
        }

        public IEnumerable<Post> PostChildren
        {
            get { return _postChildren; }
            protected set { _postChildren = new HashSet<Post>(value); }
        }

        public Post(Group group, User author, string content, Category category)
        {
            Id = Guid.NewGuid();
            SetGroup(group);
            SetAuthor(author);
            SetContent(content);
            SetCategory(category);
            IsActive = false;
            CreatedAt = DateTime.UtcNow;
        }

        protected Post()
        {
        }

        public void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new Exception("Post content can not be empty.");
            }
            Content = content;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetGroup(Group group)
        {
            Group = group;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetAuthor(User author)
        {
            Author = author;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetCategory(Category category)
        {
            Category = category;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPostParent(Post post)
        {
            PostParent = post;
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

        public void AddUpvotingUser(User user)
        {
            var upvotingUser = UpvotingUsers.SingleOrDefault(x => x.Id == user.Id);
            if (upvotingUser != null)
            {
                throw new Exception($"User: {user.Username} already upvoted post: {Content.Substring(0, 20)}...");
            }
            _upvotingUsers.Add(user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveUpvotingUser(User user)
        {
            var upvotingUser = UpvotingUsers.SingleOrDefault(x => x.Id == user.Id);
            if (upvotingUser == null)
            {
                throw new Exception($"User: {user.Username} for post: {Content.Substring(0, 20)}... not found.");
            }
            _upvotingUsers.Remove(user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddDownvotingUser(User user)
        {
            var downvotingUser = DownvotingUsers.SingleOrDefault(x => x.Id == user.Id);
            if (downvotingUser != null)
            {
                throw new Exception($"User: {user.Username} already downvoted post: {Content.Substring(0, 20)}...");
            }
            _downvotingUsers.Add(user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveDownvotingUser(User user)
        {
            var downvotingUser = DownvotingUsers.SingleOrDefault(x => x.Id == user.Id);
            if (downvotingUser == null)
            {
                throw new Exception($"User: {user.Username} for post: {Content.Substring(0, 20)}... not found.");
            }
            _downvotingUsers.Remove(user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddPostChild(Post post)
        {
            var msg = PostChildren.SingleOrDefault(x => x.Id == post.Id);
            if (msg != null)
            {
                throw new Exception($"Post: {post.Content.Substring(0, 20)}... " +
                                    $"already is a child of post: {Content.Substring(0, 20)}");
            }
            _postChildren.Add(post);
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemovePostChild(Post post)
        {
            var msg = PostChildren.SingleOrDefault(x => x.Id == post.Id);
            if (msg == null)
            {
                throw new Exception($"Post: {post.Content.Substring(0, 20)}... " +
                                    $"for post: {Content.Substring(0, 20)}... not found.");
            }
            _postChildren.Remove(post);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}