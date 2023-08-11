using Microsoft.AspNetCore.Authorization;
using Webapi.Domain.src.Entities;
using Webapi.Business.src.Dtos;
using Webapi.Business.src.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Webapi.Controller.src.Controllers
{
    [Authorize]
    public class UserController : CrudController<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        private readonly IUserService _userService;

        public UserController(IUserService baseService) : base(baseService)
        {
            _userService = baseService;
        }

        [AllowAnonymous]
        public override async Task<ActionResult<UserReadDto>> CreateOne([FromBody] UserCreateDto dto)
        {
            var createdObject = await base.CreateOne(dto);
            return CreatedAtAction(nameof(CreateOne), createdObject);
        }

        public override Task<ActionResult<UserReadDto>> GetOneById(Guid id)
        {
            return base.GetOneById(id);
        }
    }
}