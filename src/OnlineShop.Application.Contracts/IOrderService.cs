using OnlineShop.Application.Contracts.Dtos;

namespace OnlineShop.Application.Contracts;

public interface IOrderService
{
    Task CreateOrderAsync(OrderDto item);
}
