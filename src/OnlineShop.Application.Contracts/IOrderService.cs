using OnlineShop.Application.Contracts.Dtos;
using OnlineShop.Domain.Entities.Orders;

namespace OnlineShop.Application.Contracts;

public interface IOrderService
{
    Task<decimal> CreateOrderAsync(OrderDto item);
}
