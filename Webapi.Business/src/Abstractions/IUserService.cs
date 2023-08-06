using Webapi.Business.src.Dtos;
using Webapi.Domain.src.Entities;

namespace Webapi.Business.src.Abstractions
{
    public interface IUserService : IBaseService<User, UserDto>
    {
        UserDto UpdatePassword(string id, string newPassword);
        //UserDto  GetProfile(string id); --- only have this in controller because the logic is same as in getOneById 
    }
}