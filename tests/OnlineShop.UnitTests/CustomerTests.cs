using FluentAssertions;
using OnlineShop.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.UnitTests;

public class CustomerTests
{
    [Fact]
    public void Customer_Should_BeCreatedCorrectly()
    {
        var customer = new Customer
        {
            Id = 1,
            UserName = "JohnDoe",
            FirstName = "John",
            LastName = "Doe"
        };

        // Act & Assert
        customer.Id.Should().Be(1);
        customer.UserName.Should().Be("JohnDoe");
        customer.FirstName.Should().Be("John");
        customer.LastName.Should().Be("Doe");
    }
}
