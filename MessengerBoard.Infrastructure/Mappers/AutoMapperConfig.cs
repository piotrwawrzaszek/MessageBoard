using AutoMapper;
using MessageBoard.Core.Domain;
using MessengerBoard.Infrastructure.DTO;

namespace MessengerBoard.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            })
            .CreateMapper();
    }
}
