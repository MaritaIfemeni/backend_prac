using Microsoft.AspNetCore.Authorization;
using Webapi.Domain.src.Entities;
using Webapi.Business.src.Dtos;
using Webapi.Business.src.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Webapi.Controller.src.Controllers
{
    //[Authorize]
    public class OrderController : CrudController<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IOrderService _orderService;
        public OrderController(IOrderService baseService, IAuthorizationService authService) : base(baseService)
        {
            _authorizationService = authService;
            _orderService = baseService;
        }

        [HttpPost]
        public override async Task<ActionResult<OrderReadDto>> CreateOne(OrderCreateDto orderCreateDto)
        {
            var orderCreated = await _orderService.CreateOne(orderCreateDto);
            return CreatedAtAction(nameof(CreateOne), orderCreated);

        }

        [Authorize]
        public override async Task<ActionResult<OrderReadDto>> GetOneById([FromRoute] Guid id)
        {
            var user = HttpContext.User;
            var order = await _orderService.GetOneById(id);

            // Check if the user is an admin
            var isAdmin = user.IsInRole("Admin");
            if (isAdmin)
            {
                return await base.GetOneById(id);
            }
            /* resource based authorization here */
            var authorizeOwner = await _authorizationService.AuthorizeAsync(user, order, "OwnerOnly");
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
// [Authorize]
// public override async Task<ActionResult<OrderReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] OrderUpdateDto update)
// {
//     var user = HttpContext.User;
//     var order = await _orderService.GetOneById(id);
//     /* resource based authorization here */
//     var authorizeOwner = await _authorizationService.AuthorizeAsync(user, order, "OwnerOnly");
//     if (authorizeOwner.Succeeded)
//     {
//         return await base.UpdateOneById(id, update);
//     }
//     else
//     {
//         return new ForbidResult();
//     }

