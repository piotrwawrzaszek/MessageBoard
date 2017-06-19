using AutoMapper;
using MessageBoard.Core.Domain;
using MessageBoard.Infrastructure.DTO;

namespace MessageBoard.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Category, CategoryDto>();
            })
            .CreateMapper();
    }
}
