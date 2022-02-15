using App.Constants;
using Flurl;
using Flurl.Http;
using Models;

namespace App.Agents;

public class OrderAgent : IOrderAgent
{
    private List<Order> _orders;
    private readonly Url _url;

    // Has to be deleted later, for testing only
    private readonly IProductAgent _agent;

    public OrderAgent(IProductAgent productAgent)
    {
        _agent = productAgent;

        _url = new Url($"{Routes.BASE_URL}/api/Order");

        _orders = new List<Order>() {
            new Order()
            {   Id = 1,
                CustomerName = "Jon Doe",
                OrderDate = new DateTime(2022, 10, 5),
                OrderDetails = new List<OrderDetail> {
                    new OrderDetail() { Id = 0, Product = _agent.GetProductByName("Koffie").Result, TimeAdded = DateTime.Now  },
                    new OrderDetail() { Id = 0, Product = _agent.GetProductByName("Koffie").Result, TimeAdded = DateTime.Now  },
                    new OrderDetail() { Id = 0, Product = _agent.GetProductByName("Hertog-Jan").Result, TimeAdded = DateTime.Now  },
                    new OrderDetail() { Id = 0, Product = _agent.GetProductByName("Chocomel").Result, TimeAdded = DateTime.Now  } },
                IsMember = true
            },
            new Order() {
                Id = 2,
                CustomerName = "Captain Jack Sparrow",
                OrderDate = new DateTime(2021, 1, 2),
                IsMember = true
            },
            new Order() {
                Id = 3,
                CustomerName = "Baan 5",
                OrderDate = new DateTime(2022, 2, 14),
                IsMember = true,
                OrderDetails = new List<OrderDetail> {
                    new OrderDetail() { Id = 2, Product = _agent.GetProductByName("Hertog-Jan").Result, TimeAdded = new DateTime(2022, 2, 14, 21, 20, 56) },
                    new OrderDetail() { Id = 2, Product = _agent.GetProductByName("Hertog-Jan").Result, TimeAdded = new DateTime(2022, 2, 14, 21, 20, 57) },
                    new OrderDetail() { Id = 2, Product = _agent.GetProductByName("Hertog-Jan").Result, TimeAdded = new DateTime(2022, 2, 14, 21, 20, 58) },
                    new OrderDetail() { Id = 2, Product = _agent.GetProductByName("Hertog-Jan").Result, TimeAdded = new DateTime(2022, 2, 14, 21, 20, 59) },
                    new OrderDetail() { Id = 2, Product = _agent.GetProductByName("Radler Alcoholvrij").Result, TimeAdded = new DateTime(2022, 2, 14, 21, 21, 23) }},
            }
        };
    }

    public async Task<Order> CreateOrder(Order order)
    {
        //Order createdOrder = await _url.PostJsonAsync(order).ReceiveJson<Order>();
        order.Id = _orders.Count;
        _orders.Add(order);
        return order;
    }

    public async Task<Order> GetOrderByName(string name)
    {
        //_url.SetQueryParams(new { customerName = name });
        //var order = await _url.GetJsonAsync<Order>();
        //return order;
        return _orders.FirstOrDefault(order => order.CustomerName == name);
    }

    public async Task<List<Order>> GetOrders()
    {
        return _orders;
    }

    public async Task<Order> UpdateOrder(Order order)
    {
        var foundOrder = _orders.FirstOrDefault(order => order.Id == order.Id);
        if (foundOrder != null)
        {
            foundOrder = order;
        }

        return foundOrder;

        //var updateOrder = await _url.PostJsonAsync(order);
        //return order;
    }
}
