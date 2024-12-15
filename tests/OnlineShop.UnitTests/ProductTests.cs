using FluentAssertions;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.UnitTests;

public class ProductTests
{
    [Fact]
    public void Product_Should_BeCreatedCorrectly_WithProfit()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 100000,
            IsFragile = true,
            Profit = 5000,
            HasDiscount = true
        };

        product.Id.Should().Be(1);
        product.Name.Should().Be("Laptop");
        product.Price.Should().Be(100000);
        product.IsFragile.Should().Be(true);
        product.Profit.Should().Be(5000);
        product.HasDiscount.Should().Be(true);
    }
}
