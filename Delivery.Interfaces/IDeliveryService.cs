namespace Delivery.Interfaces
{
    public interface IDeliveryService
    {
        decimal CalculateDeliveryCost(float weight);

        Task<bool> IsDelivered(int orderId);
    }
}
