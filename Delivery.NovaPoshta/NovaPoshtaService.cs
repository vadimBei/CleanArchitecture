using Delivery.Interfaces;

namespace Delivery.NovaPoshta
{
    public class NovaPoshtaService : IDeliveryService
    {
        public decimal CalculateDeliveryCost(float weight)
        {
            return (decimal)weight * 10;
        }

        public Task<bool> IsDelivered(int orderId)
        {
            return Task.FromResult(true);
        }
    }
}