using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Contracts.Dtos;
using OnlineShop.Application.Orders;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Infrastructure.PersistenceBase.SQL;
using OnlineShop.Infrastructure.PersistenceBase.SQL.DbContext;

namespace OnlineShop.UnitTests;

public class OrderServiceTests
{
    [Fact]
    public async Task CreateOrder_ShouldCalculateTotalPrice_Correctly()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "TestDatabase_OrderService")
                  .Options;


        var inMemorySettings = new Dictionary<string, string> {
    { "OrderSettings:MinimumAcceptablePrice", "50000" },
    { "OrderSettings:FromOrderPlacement", "8" },
    { "OrderSettings:ToOrderPlacement", "23" }
};

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        using var context = new ApplicationDbContext(options);
        var persister = new MSSQLPersister(context);
        var service = new OrderService(persister, configuration);

        var customer = new Customer { Id = 1, UserName = "Test Customer", FirstName = "Test", LastName = "Customer" };
        var product1 = new Product { Id = Random.Shared.Next(1,int.MaxValue), Name = "Product1", Price = 20000, Profit = 3000, HasDiscount = true };
        var product2 = new Product { Id = Random.Shared.Next(1, int.MaxValue), Name = "Product2", Price = 30000, Profit = 5000, HasDiscount = false };

        context.Customers.Add(customer);
        context.Products.AddRange(product1, product2);
        await persister.CommitAsync();

        List<OrderItemDto> list = new List<OrderItemDto>();
        list.Add(new OrderItemDto() { ProductId = product1.Id, Quantity = 2 });
        list.Add(new OrderItemDto() { ProductId = product2.Id, Quantity = 1 });
        var totalPrice = await service.CreateOrderAsync(

               orderDto: new()
               {
                   CustomerId = 1,
                   Items = list.ToArray(),
                   DiscountPercentage = 10,
                   DiscountPrice = 5000
               }
          );

        var expectedTotal = ((20000 + 3000) * 2 * 0.9m) + (30000 + 5000);
        expectedTotal -= expectedTotal * 0.1m;
        expectedTotal -= 5000;

        totalPrice.Should().Be(expectedTotal);
        customer.UserName.Should().Be("Test Customer");
    }

    [Fact]
    public async Task CreateOrder_ShouldThrowException_IfOutsideAllowedTime()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "TestDatabase_OrderService")
                  .Options;


        var inMemorySettings = new Dictionary<string, string> {
    { "OrderSettings:MinimumAcceptablePrice", "50000" },
    { "OrderSettings:FromOrderPlacement", "8" },
    { "OrderSettings:ToOrderPlacement", "19" }
};

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();


        using var context = new ApplicationDbContext(options);
        var persister = new MSSQLPersister(context);
        var service = new OrderService(persister, configuration);

        var customer = new Customer { Id = 1, UserName = "Test Customer-2", FirstName = "Test", LastName = "Customer" };

        context.Customers.Add(customer);
        await context.SaveChangesAsync();

        var originalTime = DateTime.Now;

        List<OrderItemDto> list = new List<OrderItemDto>();
        list.Add(new OrderItemDto() { ProductId = 1, Quantity = 2 });
        list.Add(new OrderItemDto() { ProductId = 2, Quantity = 1 });
        var exception = await Assert.ThrowsAsync<Exception>(() =>
              service.CreateOrderAsync(
               orderDto: new()
               {
                   CustomerId = 1,
                   Items = list.ToArray(),
                   DiscountPercentage = 10,
                   DiscountPrice = 5000
               }
          )
        );

        exception.Message.Should().Be(PersianLexicon.Error_UnValidOrdeRplacementPeriod);
    }

}
