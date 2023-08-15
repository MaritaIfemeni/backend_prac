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
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserService _userService;

        public UserController(IUserService baseService, IAuthorizationService authService) : base(baseService)
        {
            _authorizationService = authService;
            _userService = baseService;
        }

        [AllowAnonymous]
        [HttpPost]
        public override async Task<ActionResult<UserReadDto>> CreateOne([FromBody] UserCreateDto dto)
        {
            return CreatedAtAction(nameof(CreateOne), await _userService.CreateOne(dto));
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("admin")]
        public async Task<ActionResult<UserReadDto>> CreateAdmin([FromBody] UserCreateDto dto)
        {
            return CreatedAtAction(nameof(CreateAdmin), await _userService.GreateAdmin(dto));
        }


        public override async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll([FromQuery] QueryOptions queryOptions)
        {
            return Ok(await _userService.GetAll(queryOptions));
        }

       
        public override async Task<ActionResult<UserReadDto>> GetOneById([FromRoute] Guid id)
        {
            var user = HttpContext.User;
            var profile = await _userService.GetOneById(id);

            var isAdmin = user.IsInRole("Admin");
            if (isAdmin)
            {
                return await base.GetOneById(id);
            }
            /* resource based authorization here */
            var authorizeOwner = await _authorizationService.AuthorizeAsync(user, profile, "OwnerOnly");
            if (authorizeOwner.Succeeded)
            {
                return await base.GetOneById(id);
            }
            else
            {
                return new ForbidResult();
            }
        }
    }
}