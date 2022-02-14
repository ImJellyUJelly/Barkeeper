using App.Constants;
using Flurl;
using Flurl.Http;
using Models;

namespace App.Agents;

public class OrderAgent : IOrderAgent
{
    private List<Order> _orders;
    private readonly Url _url;

    public OrderAgent()
    {
        _url = new Url($"{Routes.BASE_URL}/api/Order");

        _orders = new List<Order>() {
                new Order()
                {   Id = 0,
                    CustomerName = "Jelle Schrader",
                    OrderDate = new DateTime(2022, 10, 5),
                    OrderDetails = new List<OrderDetail> {
                        new OrderDetail() { Product = new Product() { Id = 0, Name = "Koffie", MemberPrice = 1.20M, Price = 1.75M }, TimeAdded = DateTime.Now },
                        new OrderDetail() { Product = new Product() { Id = 1, Name = "Thee", MemberPrice = 1.20M, Price = 1.75M }, TimeAdded = DateTime.Now } },
                    IsMember = true
                },
                new Order() {
                    Id = 1,
                    CustomerName = "Tom van Grinsven",
                    OrderDate = new DateTime(2021, 1, 2),
                    IsMember = true
                },
                new Order() {
                    Id = 2,
                    CustomerName = "Danielle van den Bosch-Schwanen",
                    OrderDate = new DateTime(2022, 5, 20),
                    IsMember = true
                }
        };
    }

    public async Task CreateOrder(Order order)
    {
        //_orders.Add(order);
        var result = await _url.PostJsonAsync(order);
    }

    public async Task<Order?> GetOrderByName(string name)
    {
        _url.SetQueryParams(new { customerName = name });
        var order = await _url.GetJsonAsync<Order>();
        return order;
    }

    public async Task<List<Order>> GetOrders()
    {
        return _orders;
    }

    public async Task UpdateOrder(Order order)
    {
        var foundOrder = _orders.FirstOrDefault(order => order.Id == order.Id);
        if (foundOrder != null)
        {
            foundOrder = order;
        }
    }
}
