using MediatR;
using WebApi.UseCases.Orders.Dtos;

namespace WebApi.UseCases.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(CreateOrderDto CreateDto) : IRequest<int>;
}
