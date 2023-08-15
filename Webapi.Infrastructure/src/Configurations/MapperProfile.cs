using AutoMapper;
using Webapi.Business.src.Dtos;
using Webapi.Domain.src.Entities;

namespace Webapi.Infrastructure.src.Configurations
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserReadDto, User>();

            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<ProductCreateDto, Product>();


            CreateMap<OrderUpdateDto, Order>();
            CreateMap<Order, OrderReadDto>()
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));
            CreateMap<OrderCreateDto, Order>();
            CreateMap<Order, OrderCreateDto>();
            CreateMap<OrderReadDto, Order>();
            CreateMap<Order, OrderUpdateDto>();

            CreateMap<OrderDetailUpdateDto, OrderDetail>();
            CreateMap<OrderDetailCreateDto, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailReadDto>();
            CreateMap<OrderDetail, OrderDetailCreateDto>();

        }
    }
}