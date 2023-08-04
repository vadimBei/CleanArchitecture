using MediatR;
using MobileApi.UseCases.Orders.Dtos;

namespace MobileApi.UseCases.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public CreateOrderDto CreateDto { get; set; }
    }
}
