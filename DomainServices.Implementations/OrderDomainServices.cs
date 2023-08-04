using DomainServices.Interfaces;
using Entities.Models;

namespace DomainServices.Implementations
{
    public class OrderDomainServices : IOrderDomainServices
    {
        public decimal GetTotal(Order order, CalculateDeliveryCost deliveryCostCalculator)
        {
            var totalPrice = order.Items.Sum(x => x.Quantity * x.Product.Price);

            decimal deliveryCost = 0;

            if (totalPrice < 1000)
            {
                var totalWeight = order.Items.Sum(x => x.Product.Weight);

                deliveryCost = deliveryCostCalculator(totalWeight);
            }
 
            return deliveryCost + totalPrice;
        }
    }
}
