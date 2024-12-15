using OnlineShop.Application.Base;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Contracts.Dtos;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Infrastructure.PersistenceBase;

namespace OnlineShop.Application.Customers;

public class CustomerService : BaseService, ICustomerService
{
    public CustomerService(IPersisterlayers persisterlayers) : base(persisterlayers)
    {
    }

    public async Task<int> CreateCustomer(CustomerDto customerDto)
    {
        await _CheckCustomerExist(customerDto.UserName);
        Customer customer = new()
        {
            UserName = customerDto.UserName,
            CDT = DateTime.Now,
            FirstName = customerDto.FirstName,
            LastName = customerDto.LastName,
        };
        await _Persisterlayers.AddAsync(customer);
        await _Persisterlayers.CommitAsync();
        return customer.Id;
    }

    private async Task _CheckCustomerExist(string userName)
    {
        var customer = await _Persisterlayers.Get<Customer>(c => c.UserName == userName);
        if (customer != null)
            throw new Exception(PersianLexicon.Error_DublicateUser);
    }
}
