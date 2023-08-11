using AutoMapper;
using Webapi.Business.src.Dtos;
using Webapi.Domain.src.Entities;

namespace Webapi.Infrastructure.src.Configurations
{
    public class MapperProfile :Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserCreateDto, User>();
        }
    }
}