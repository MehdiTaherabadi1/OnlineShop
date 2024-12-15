using OnlineShop.Application.Contracts.Dtos;

namespace OnlineShop.Application.Contracts;

public interface ICustomerService
{
    Task<int> CreateCustomer(CustomerDto customerDto);
}
