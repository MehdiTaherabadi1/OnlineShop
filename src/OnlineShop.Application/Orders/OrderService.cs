using Microsoft.Extensions.Configuration;
using OnlineShop.Application.Base;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Contracts.Dtos;
using OnlineShop.Application.Helpers;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Infrastructure.PersistenceBase;

namespace OnlineShop.Application.Orders;

public class OrderService : BaseService, IOrderService
{
    private IConfiguration _Configuration;
    public OrderService(IPersisterlayers persisterlayers, IConfiguration configuration) : base(persisterlayers)
    {
        _Configuration = configuration;
    }

    public async Task CreateOrderAsync(OrderDto orderDto)
    {
        var ordersettings = _Configuration.GetSection(ConfigLexicon.OrderSettings);
        Guard.CheckValidOrderPlacementPeriod(Convert.ToInt32(ordersettings[ConfigLexicon.FromOrderPlacement]), Convert.ToInt32(ordersettings[ConfigLexicon.ToOrderPlacement]));

        var minimumAcceptablePrice = ordersettings[ConfigLexicon.MinimumAcceptablePrice];

        Customer customer = await _Persisterlayers.Get<Customer>(orderDto.CustomerId);
        if (customer == null)
            throw new Exception("The customer is not found");

        Order order = new()
        {
            CustomerId = orderDto.CustomerId,
            CDT = DateTime.Now,
            ShippingType = PersianLexicon.Normal_ShippingType,
            TotalPrice = 0,
            DiscountPercentage = orderDto.DiscountPercentage,
            DiscountPrice = orderDto.DiscountPrice,
            OrderItems = new List<OrderItem>()
        };
        var totalPrice = await _SetProducts(orderDto, order);

        if (totalPrice < Convert.ToInt32(minimumAcceptablePrice))
            throw new Exception(PersianLexicon.Error_UnValidOrder);

        if (order.DiscountPercentage.HasValue && order.DiscountPercentage.Value > 0)
            totalPrice -= totalPrice * (order.DiscountPercentage.Value / 100);

        if (order.DiscountPrice.HasValue && order.DiscountPrice.Value > 0)
            totalPrice -= order.DiscountPrice.Value;

        order.TotalPrice = Math.Max(totalPrice, 0);
        await _Persisterlayers.AddAsync(order);
        await _Persisterlayers.CommitAsync();
    }

    private async Task<decimal> _SetProducts(OrderDto orderDto, Order order)
    {
        decimal totalPrice = 0;

        foreach (var item in orderDto.Items)
        {
            var product = await _Persisterlayers.Get<Product>(item.ProductId);

            if (product == null)
                continue;

            decimal price = product.Price;

            price += product.Profit;

            if (product.HasDiscount)
                price *= 0.9m;

            if (product.IsFragile)
                order.ShippingType = PersianLexicon.VanguardPost;
            else
                order.ShippingType = PersianLexicon.NormalPost;

            totalPrice += price * item.quantity;

            order.OrderItems.Add(new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.quantity
            });
        }

        return totalPrice;
    }
}
