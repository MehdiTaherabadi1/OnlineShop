using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Contracts.Dtos;
using OnlineShop.WebAPI.Controllers.Base;

namespace OnlineShop.WebAPI.Controllers;

public class CustomerController : BaseApiController
{
    private ICustomerService _CustomerService;

    public CustomerController(ICustomerService customerService)
    {
        _CustomerService = customerService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CustomerDto customerDto)
    {
        var customerId = await _CustomerService.CreateCustomer(customerDto);
        return Ok(customerId);
    }
}
