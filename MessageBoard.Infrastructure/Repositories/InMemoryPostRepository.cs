using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBoard.Core.Domain;
using MessageBoard.Core.Repositories;

namespace MessageBoard.Infrastructure.Repositories
{
    public class InMemoryPostRepository : IPostRepository
    {
        private static ISet<Post> _posts = new HashSet<Post>();


        public async Task AddAsync(Post post)
        {
            _posts.Add(post);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Post>> BrowseAsync()
            => await Task.FromResult(_posts);

        public async Task<Post> GetAsync(Guid id)
            => await Task.FromResult(_posts.SingleOrDefault(x => x.Id == id));

        public async Task DeleteAsync(Post post)
        {
            _posts.Remove(post);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Post post)
        {
            await Task.CompletedTask;
        }
    }
}
