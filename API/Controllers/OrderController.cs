using API.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private IOrderService _orderservice;

    public OrderController(IOrderService orderService)
    {
        _orderservice = orderService;
    }

    [HttpPost]
    public IActionResult CreateOrder(Order order)
    {
        if (order == null)
        {
            return BadRequest();
        }

        order.Id = _orderservice.CreateOrder(order);
        return Ok(order);
    }

    [HttpGet]
    public IActionResult GetOrderById(int orderId)
    {
        var order = _orderservice.GetOrderById(orderId);
        if (order == null)
        {
            return NotFound($"Order with ID: {orderId} could not tbe found.");
        }

        return Ok(order);
    }
}
