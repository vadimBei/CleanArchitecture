using AutoMapper;
using Entities.Models;
using WebApi.UseCases.Orders.Dtos;

namespace WebApi.UseCases.Orders.Utils
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<OrderItemDto, OrderItem>();
        }
    }
}
