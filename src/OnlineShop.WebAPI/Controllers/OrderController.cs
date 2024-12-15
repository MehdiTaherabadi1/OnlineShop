using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Contracts.Dtos;
using OnlineShop.WebAPI.Controllers.Base;

namespace OnlineShop.WebAPI.Controllers;

public class OrderController : BaseApiController
{
    private IOrderService _OrderService;

    public OrderController(IOrderService orderService)
    {
        _OrderService = orderService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderDto orderDto)
    {
        await _OrderService.CreateOrderAsync(orderDto);
        return Ok(PersianLexicon.SucessOpertion);
    }
}
