using Webapi.Domain.src.Entities;
using Webapi.Business.src.Dtos;
using Webapi.Business.src.Abstractions;


namespace Webapi.Controller.src.Controllers
{
    public class UserController : CrudController<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        private readonly IUserService _userService;

        public UserController(IUserService baseService) : base(baseService)
        {
            _userService = baseService;
        }
    }
}