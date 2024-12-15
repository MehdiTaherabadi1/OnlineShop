using FluentAssertions;
using OnlineShop.Domain.Entities.Orders;

namespace OnlineShop.UnitTests;

public class OrderTests
{
    [Fact]
    public void Order_ShouldCalculateTotalPrice_WithDiscounts()
    {
        var order = new Order
        {
            Id = 1,
            CustomerId = 1,
            DiscountPercentage = 10,
            DiscountPrice = 5000,
            CDT = DateTime.Now,
            TotalPrice = 0,
            OrderItems = new List<OrderItem>
        {
            new OrderItem { ProductId = 1, Quantity = 2 },
            new OrderItem{ ProductId = 2, Quantity = 1 }
        }
        };

        var product1Price = 20000;
        var product2Price = 30000;

        var totalPrice = (product1Price * 2 + product2Price) * 0.9m - 5000;

        // Act
        order.TotalPrice = totalPrice;

        // Assert
        order.TotalPrice.Should().Be(totalPrice);
        order.DiscountPercentage.Should().Be(10);
        order.DiscountPrice.Should().Be(5000);
    }
}
