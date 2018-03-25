using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessageBoard.Core.Domain;

namespace MessageBoard.Core.Repositories
{
    public interface IConversationRepository : IRepository
    {
        Task<Conversation> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task AddAsync(Conversation conversation);
        Task UpdateAsync(Conversation conversation);
        Task<IEnumerable<Conversation>> BrowseAsync();
        //Task<IEnumerable<Conversation>> BrowseAsync(User admin);
        //Task<IEnumerable<Conversation>> BrowseAsync(string name);
        //Task<IEnumerable<Conversation>> BrowseAsync(bool isActive);
        //Task<IEnumerable<Conversation>> BrowseAsync(DateTime createdAt);
    }
}