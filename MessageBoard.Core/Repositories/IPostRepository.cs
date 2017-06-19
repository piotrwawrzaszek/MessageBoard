using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessageBoard.Core.Domain;

namespace MessageBoard.Core.Repositories
{
    public interface IPostRepository : IRepository
    {
        Task<Post> GetAsync(Guid id);
        Task DeleteAsync(Post post);
        Task AddAsync(Post post);
        Task UpdateAsync(Post post);
        Task<IEnumerable<Post>> BrowseAsync();
        //Task<IEnumerable<Post>> BrowseAsync(User author);
        //Task<IEnumerable<Post>> BrowseAsync(Group group);
        //Task<IEnumerable<Post>> BrowseAsync(bool isActive);
        //Task<IEnumerable<Post>> BrowseAsync(string content);
        //Task<IEnumerable<Post>> BrowseAsync(Post parent);
        //Task<IEnumerable<Post>> BrowseAsync(Category category);
        //Task<IEnumerable<Post>> BrowseAsync(DateTime createdAt);
    }
}
