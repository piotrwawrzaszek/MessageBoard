using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessageBoard.Core.Domain;

namespace MessageBoard.Core.Repositories
{
    public interface IGroupRepository : IRepository
    {
        Task<Group> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task AddAsync(Group group);
        Task UpdateAsync(Group group);
        Task<IEnumerable<Group>> BrowseAsync();
        //Task<IEnumerable<Group>> BrowseAsync(User admin);
        //Task<IEnumerable<Group>> BrowseAsync(string name);
        //Task<IEnumerable<Group>> BrowseAsync(bool isActive);
        //Task<IEnumerable<Group>> BrowseAsync(DateTime createdAt);
    }
}
