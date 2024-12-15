using FluentAssertions;
using OnlineShop.Domain.Entities.Orders;

namespace OnlineShop.UnitTests;

public class OrderItemTests
{
    [Fact]
    public void OrderItem_ShouldHaveCorrectProductAndQuantity()
    {
        var orderItem = new OrderItem
        {
            Id = 1,
            ProductId = 1,
            Quantity = 3
        };

        orderItem.ProductId.Should().Be(1);
        orderItem.Quantity.Should().Be(3);
    }
}
