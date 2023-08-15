using Microsoft.AspNetCore.Authorization;
using Webapi.Domain.src.Entities;
using Webapi.Business.src.Dtos;
using Webapi.Business.src.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Webapi.Controller.src.Controllers
{
    public class UserController : CrudController<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        private readonly IUserService _userService;

        public UserController(IUserService baseService) : base(baseService)
        {
            _userService = baseService;
        }

        //     // [Authorize(Roles = "Admin")]
        //     // [HttpPost("admin")]
        //     public async Task<ActionResult<UserReadDto>> CreateAdmin([FromBody] UserCreateDto dto)
        //     {
        //         return CreatedAtAction(nameof(CreateAdmin), await _userService.GreateAdmin(dto));
        //     }


        //    //[Authorize(Roles = "Admin")]
        //     public override async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll([FromQuery] QueryOptions queryOptions)
        //     {

        //         return Ok(await _userService.GetAll(queryOptions));
        //     }

        [AllowAnonymous]
        public override async Task<ActionResult<UserReadDto>> GetOneById([FromRoute] Guid id)
        {
            return Ok(await _userService.GetOneById(id));
        }
    }
}