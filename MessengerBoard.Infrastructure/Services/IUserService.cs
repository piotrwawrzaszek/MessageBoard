using System.Threading.Tasks;
using MessengerBoard.Infrastructure.DTO;

namespace MessengerBoard.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task RegisterAsync(string email, string username, string password, string role);
        Task LoginAsync(string email, string password);
        Task<UserDto> GetAsync(string email);
    }
}
