using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.UseCases.Orders.Commands.CreateOrder;
using WebApi.UseCases.Orders.Dtos;
using WebApi.UseCases.Orders.Queries.GetOrderById;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly ISender _sender;

        public OrderController(
            ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> GetOrderById(int id)
        {
            var order = await _sender.Send(new GetOrderByIdQuery(id));

            return order;
        }

        [HttpPost]
        public async Task<int> CreateOrder(CreateOrderDto createDto)
        {
            var orderId = await _sender.Send(new CreateOrderCommand(createDto));

            return orderId;
        }
    }
}
