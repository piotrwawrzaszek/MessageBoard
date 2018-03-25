using MessageBoard.Infrastructure.DTO;

namespace MessageBoard.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email, string role);
    }
}
