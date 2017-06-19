using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessageBoard.Core.Domain;

namespace MessageBoard.Core.Repositories
{
    public interface IMessageRepository : IRepository
    {
        Task<Message> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task AddAsync(Message message);
        Task UpdateAsync(Message message);
        Task<IEnumerable<Message>> BrowseAsync();
        //Task<IEnumerable<Message>> BrowseAsync(User author);
        //Task<IEnumerable<Message>> BrowseAsync(string content);
        //Task<IEnumerable<Message>> BrowseAsync(DateTime createdAt);
        //Task<IEnumerable<Message>> BrowseAsync(Conversation conversation);
    }
}
