using System;
using System.Collections.Generic;
using MessageBoard.Core.Domain;
using System.Threading.Tasks;

namespace MessageBoard.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(User user);
        Task<IEnumerable<User>> BrowseAsync();
        //Task<IEnumerable<User>> BrowseAsync(string role);
        //Task<IEnumerable<User>> BrowseAsync(bool isActive);
        //Task<IEnumerable<User>> BrowseAsync(DateTime createdAt);
    }
}
