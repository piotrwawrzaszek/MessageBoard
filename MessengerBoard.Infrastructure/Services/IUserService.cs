using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MessengerBoard.Infrastructure.DTO;

namespace MessengerBoard.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string username, string password, string role);
        Task<UserDto> GetAsync(string email);
    }
}
