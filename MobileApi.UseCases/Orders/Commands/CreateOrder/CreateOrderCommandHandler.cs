using AutoMapper;
using DataAccess.Interfaces;
using Entities.Enums;
using Entities.Models;
using MediatR;

namespace MobileApi.UseCases.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateOrderCommandHandler(
            IMapper mapper,
            IApplicationDbContext applicationDbContext)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request.CreateDto);
            order.CreateDate = DateTime.Now;
            order.Status = OrderStatus.Created;

            _applicationDbContext.Orders.Add(order);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
