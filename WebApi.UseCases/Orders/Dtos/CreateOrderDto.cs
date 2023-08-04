namespace WebApi.UseCases.Orders.Dtos
{
    public record CreateOrderDto(List<OrderItemDto> Items);
}
