using Microsoft.AspNetCore.Authorization;
using Webapi.Domain.src.Entities;
using Webapi.Business.src.Dtos;
using Webapi.Business.src.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Webapi.Controller.src.Controllers
{
    [Authorize]
    public class OrderController : CrudController<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {

        private readonly IOrderService _orderService;
        public OrderController(IOrderService baseService) : base(baseService)
        {
            _orderService = baseService;
        }
    }
}