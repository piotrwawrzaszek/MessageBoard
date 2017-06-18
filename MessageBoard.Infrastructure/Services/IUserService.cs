using System.Threading.Tasks;
using MessageBoard.Infrastructure.DTO;
using System;
using System.Collections.Generic;

namespace MessageBoard.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task RegisterAsync(Guid userId, string email, string username, string password, string role);
        Task<IEnumerable<UserDto>> BrowseAsync();
        Task LoginAsync(string email, string password);
        Task<UserDto> GetAsync(string email);
    }
}
