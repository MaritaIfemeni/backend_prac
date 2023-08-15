using Webapi.Business.src.Dtos;
using Webapi.Domain.src.Entities;

namespace Webapi.Business.src.Abstractions
{
    public interface IUserService : IBaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        Task<UserReadDto> UpdatePassword(Guid id, string newPassword);
        //UserDto  GetProfile(string id); --- only have this in controller because the logic is same as in getOneById 
       Task<UserReadDto> GreateAdmin(UserCreateDto CreatedDto);
   
    }
}