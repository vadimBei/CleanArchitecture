using DataAccess.Interfaces;
using Delivery.Interfaces;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace WebApi.UseCases.Orders.BackgroundJobs
{
    public class UpdateDeliveryStatusJob
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateDeliveryStatusJob(
            IDeliveryService deliveryService,
            IApplicationDbContext applicationDbContext)
        {
            _deliveryService = deliveryService;
            _applicationDbContext = applicationDbContext;
        }

        public async Task ExecutAsync()
        {
            var orders = await _applicationDbContext.Orders
                .Where(x => x.Status == OrderStatus.Created)
                .ToListAsync();

            var deliveryStatusChecking = orders
                .Select(x => new
                {
                    Order = x,
                    Task = _deliveryService.IsDelivered(x.Id)
                })
                .ToList();

            await Task.WhenAll(deliveryStatusChecking.Select(x => x.Task));

            foreach (var checking in deliveryStatusChecking)
            {
                if (checking.Task.Result)
                {
                    checking.Order.Status = OrderStatus.Delivered;
                }
            }

            await _applicationDbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
