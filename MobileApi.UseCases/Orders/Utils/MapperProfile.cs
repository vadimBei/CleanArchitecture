using AutoMapper;
using Entities.Models;
using MobileApi.UseCases.Orders.Dtos;

namespace MobileApi.UseCases.Orders.Utils
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
