using Microsoft.AspNetCore.Authorization;
using Webapi.Domain.src.Entities;
using Webapi.Business.src.Dtos;
using Webapi.Business.src.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Webapi.Domain.src.Shared;

namespace Webapi.Controller.src.Controllers
{
    public class UserController : CrudController<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        private readonly IUserService _userService;

        public UserController(IUserService baseService) : base(baseService)
        {
            _userService = baseService;
        }

        // [AllowAnonymous]
        // public override async Task<ActionResult<UserReadDto>> CreateOne([FromBody] UserCreateDto dto)
        // {
        //     var createdObject = await base.CreateOne(dto);
        //     var createdUser = CreatedAtAction(nameof(CreateOne), createdObject);
        //     return createdUser;
        // }

        // public override async Task<ActionResult<UserReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] UserUpdateDto dto)
        // {

        //     var updatedUser = await base.UpdateOneById(id, dto);
        //     return updatedUser;
        // }

        // //[Authorize]
        // public override async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll([FromQuery] QueryOptions queryOptions)
        // {
        //     return Ok(await base.GetAll(queryOptions));
        // }

        [AllowAnonymous]
        public override async Task<ActionResult<UserReadDto>> GetOneById([FromRoute] Guid id)
        {
            var foundUser = await base.GetOneById(id);
            return foundUser;
        }
    }
}