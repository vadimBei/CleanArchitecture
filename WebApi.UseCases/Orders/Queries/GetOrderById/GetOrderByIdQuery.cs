using MediatR;
using WebApi.UseCases.Orders.Dtos;

namespace WebApi.UseCases.Orders.Queries.GetOrderById
{
    public record GetOrderByIdQuery(int Id) : IRequest<OrderDto>;
}
