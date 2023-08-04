using AutoMapper;
using Entities.Models;

namespace WebApi.UseCases.Orders.Dtos
{
    [AutoMap(typeof(Order))]
    public record OrderDto
    {
        public int Id { get; set; }

        public decimal Total { get; set; }
    }
}
