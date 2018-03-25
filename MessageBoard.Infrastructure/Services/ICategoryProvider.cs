using MessageBoard.Infrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageBoard.Infrastructure.Services
{
    public interface ICategoryProvider : IService
    {
        Task<IEnumerable<CategoryDto>> BrowseAsync();
        Task<CategoryDto> GetAsync(string type, string name);
    }
}
