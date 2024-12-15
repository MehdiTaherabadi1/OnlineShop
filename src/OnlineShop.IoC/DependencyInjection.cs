using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Customers;
using OnlineShop.Application.Orders;
using OnlineShop.Application.Products;
using OnlineShop.Infrastructure.PersistenceBase;
using OnlineShop.Infrastructure.PersistenceBase.SQL;

namespace OnlineShop.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration)
    {
        MSSQLDependencyInjection.AddIoC(services, configuration);
        services.AddScoped<IPersisterlayers, MSSQLPersister>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
