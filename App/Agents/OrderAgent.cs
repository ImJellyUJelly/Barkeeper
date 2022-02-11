using App.Constants;
using Models;

namespace App.Agents;

public class OrderAgent : IOrderAgent
{
    private const string path = $"{Routes.BASE_URL}/Order";
    private List<Order> _orders;

    public OrderAgent()
    {
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

    public void CreateOrder(Order order)
    {
        _orders.Add(order);
    }

    public Order? GetOrderByName(string name)
    {
        return _orders.FirstOrDefault(order => order.CustomerName == name);
    }

    public List<Order> GetOrders()
    {
        return _orders;
    }

    public void UpdateOrder(Order order)
    {
        var foundOrder = _orders.FirstOrDefault(order => order.Id == order.Id);
        if (foundOrder != null)
        {
            foundOrder = order;
        }
    }
}
