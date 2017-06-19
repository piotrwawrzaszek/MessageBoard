using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MessageBoard.Core.Domain;
using MessageBoard.Infrastructure.DTO;

namespace MessageBoard.Infrastructure.Services
{
    public interface IPostService : IService
    {
        Task<PostDetailsDto> GetAsync(Guid id);
        Task AddAsync(Guid id, Group group, User author, string content, Category category);
        Task SetCategory(Guid postId, string type, string name);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<PostDto>> BrowseAsync();
    }
}