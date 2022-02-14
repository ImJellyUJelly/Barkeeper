using API.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public IActionResult CreateOrder(Order order)
    {
        if (order == null)
        {
            return BadRequest();
        }

        order = _orderService.CreateOrder(order);
        return Ok(order);
    }

    //[HttpGet(Name = "GetById")]
    //public IActionResult GetOrderById(int orderId)
    //{
    //    var order = _orderservice.GetOrderById(orderId);
    //    if (order == null)
    //    {
    //        return NotFound($"Order with ID: {orderId} could not tbe found.");
    //    }

    //    return Ok(order);
    //}

    [HttpGet(Name = "GetByName")]
    public ActionResult<Order> GetOrderByName(string customerName)
    { 
        var order = _orderService.GetOrderByName(customerName);
        if (order == null)
        {
            return NotFound($"Order with customername: {customerName} could not tbe found.");
        }

        return Ok(order);
    }
}
