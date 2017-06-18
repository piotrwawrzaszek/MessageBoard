using MessengerBoard.Infrastructure.DTO;

namespace MessengerBoard.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email, string role);
    }
}
