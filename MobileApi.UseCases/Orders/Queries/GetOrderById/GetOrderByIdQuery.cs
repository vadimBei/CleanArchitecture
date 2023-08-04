using MediatR;
using MobileApi.UseCases.Orders.Dtos;

namespace MobileApi.UseCases.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
}
