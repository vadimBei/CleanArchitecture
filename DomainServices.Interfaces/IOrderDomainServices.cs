using Entities.Models;

namespace DomainServices.Interfaces
{
    public interface IOrderDomainServices
    {
        decimal GetTotal(Order order, CalculateDeliveryCost deliveryCostCalculator);
    }
}
