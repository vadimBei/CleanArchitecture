using AutoMapper;
using DataAccess.Interfaces;
using Email.Interfaces;
using Entities.Enums;
using Entities.Models;
using MediatR;
using WebApp.Interfaces;

namespace WebApi.UseCases.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IBackgroundJobService _backgroundJobService;

        public CreateOrderCommandHandler(
            IMapper mapper,
            ICurrentUserService currentUserService,
            IApplicationDbContext applicationDbContext,
            IBackgroundJobService backgroundJobService)
        {
            _mapper = mapper;
            _currentUserService = currentUserService;
            _applicationDbContext = applicationDbContext;
            _backgroundJobService = backgroundJobService;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request.CreateDto);
            order.CreateDate = DateTime.Now;
            order.Status = OrderStatus.Created;

            _applicationDbContext.Orders.Add(order);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            _backgroundJobService.Schedule<IEmailService>(emailService =>
                    emailService.Send(
                        _currentUserService.Email,
                        "Order created",
                        $"Order {order.Id} created"));

            return order.Id;
        }
    }
}
