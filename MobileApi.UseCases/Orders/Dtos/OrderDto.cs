using AutoMapper;
using Entities.Models;

namespace MobileApi.UseCases.Orders.Dtos
{
    [AutoMap(typeof(Order))]
    public class OrderDto
    {
        public int Id { get; set; }

        public decimal Total { get; set; }
    }
}
