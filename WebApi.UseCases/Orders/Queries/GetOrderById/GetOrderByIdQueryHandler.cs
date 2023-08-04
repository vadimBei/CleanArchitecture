using AutoMapper;
using DataAccess.Interfaces;
using Delivery.Interfaces;
using DomainServices.Interfaces;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utils.Exceptions;
using WebApi.UseCases.Orders.Dtos;

namespace WebApi.UseCases.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IMapper _mapper;
        private readonly IDeliveryService _deliveryService;
        private readonly IOrderDomainServices _orderDomainServices;
        private readonly IApplicationDbContext _applicationDbContext;

        public GetOrderByIdQueryHandler(
            IMapper mapper,
            IDeliveryService deliveryService,
            IOrderDomainServices orderDomainServices, 
            IApplicationDbContext applicationDbContext)
        {
            _mapper = mapper;
            _deliveryService = deliveryService;
            _orderDomainServices = orderDomainServices;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _applicationDbContext.Orders
                .AsNoTracking()
                .Include(x => x.Items)
                    .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (order == null)
            {
                throw new NotFoundException(typeof(Order), request.Id);
            }

            var orderDto = _mapper.Map<OrderDto>(order);
            orderDto.Total = _orderDomainServices.GetTotal(order, _deliveryService.CalculateDeliveryCost);

            return orderDto;
        }
    }
}
