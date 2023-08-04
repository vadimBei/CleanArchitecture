using MediatR;
using Microsoft.AspNetCore.Mvc;
using MobileApi.UseCases.Orders.Commands.CreateOrder;
using MobileApi.UseCases.Orders.Dtos;
using MobileApi.UseCases.Orders.Queries.GetOrderById;

namespace MobileApi.Controllers
{
    [ApiController]
    [Route("api/mobile/orders")]
    public class MobileOrderController : ControllerBase
    {
        private readonly ISender _sender;

        public MobileOrderController(
            ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> GetOrderById(int id)
        {
            var order = await _sender.Send(new GetOrderByIdQuery()
            {
                Id = id
            });

            return order;
        }

        [HttpPost]
        public async Task<int> CreateOrder(CreateOrderDto createDto)
        {
            var orderId = await _sender.Send(new CreateOrderCommand()
            {
                CreateDto = createDto
            });

            return orderId;
        }
    }
}