using System.Threading.Tasks;

namespace MessageBoard.Infrastructure.Services
{
    public interface IDataInitializer : IService
    {
        Task SeedAsync();
    }
}
