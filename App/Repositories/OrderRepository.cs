using App.Contexts;
using App.Models;

namespace App.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly BarkeeperContext _dbContext;

    // For testing only
    //private readonly List<Order> _orders;
    //private readonly IProductRepository _productRepository;

    public OrderRepository(BarkeeperContext dbContext, IProductRepository productRepository)
    {
        _dbContext = dbContext;

        //_productRepository = productRepository;
        //_orders = new List<Order>() {
        //    new Order()
        //    {   Id = 1,
        //        Customer = new Customer() { Name = "Jon Doe" },
        //        OrderDate = new DateTime(2022, 10, 5),
        //        OrderDetails = new List<OrderDetail> {
        //            new OrderDetail() { Id = 0, Product = productRepository.GetProductByName("Koffie"), TimeAdded = DateTime.Now  },
        //            new OrderDetail() { Id = 0, Product = productRepository.GetProductByName("Koffie"), TimeAdded = DateTime.Now  },
        //            new OrderDetail() { Id = 0, Product = productRepository.GetProductByName("Hertog-Jan"), TimeAdded = DateTime.Now  },
        //            new OrderDetail() { Id = 0, Product = productRepository.GetProductByName("Chocomel"), TimeAdded = DateTime.Now  } },
        //        IsMember = true
        //    },
        //    new Order() {
        //        Id = 2,
        //        Customer = new Customer() { Name = "Captain Jack Sparrow" },
        //        OrderDate = new DateTime(2021, 1, 2),
        //        IsMember = false
        //    },
        //    new Order() {
        //        Id = 3,
        //        Customer = new Customer() { Name = "Baan 5" },
        //        OrderDate = new DateTime(2022, 2, 14),
        //        IsMember = true,
        //        OrderDetails = new List<OrderDetail> {
        //            new OrderDetail() { Id = 2, Product = productRepository.GetProductByName("Hertog-Jan"), TimeAdded = new DateTime(2022, 2, 14, 21, 20, 56) },
        //            new OrderDetail() { Id = 2, Product = productRepository.GetProductByName("Hertog-Jan"), TimeAdded = new DateTime(2022, 2, 14, 21, 20, 57) },
        //            new OrderDetail() { Id = 2, Product = productRepository.GetProductByName("Hertog-Jan"), TimeAdded = new DateTime(2022, 2, 14, 21, 20, 58) },
        //            new OrderDetail() { Id = 2, Product = productRepository.GetProductByName("Hertog-Jan"), TimeAdded = new DateTime(2022, 2, 14, 21, 20, 59) },
        //            new OrderDetail() { Id = 2, Product = productRepository.GetProductByName("Radler Alcoholvrij"), TimeAdded = new DateTime(2022, 2, 14, 21, 21, 23) }},
        //        Comment = "Op Baan 5 staan Will Smith, De Koning Van Spanje en Rapper Sjors.\n"
        //    }
        //};
        //foreach (var order in _orders)
        //{
        //    decimal totalPrice = 0.00M;
        //    order.OrderDetails.ForEach(od => totalPrice += (order.IsMember ? od.Product.MemberPrice : od.Product.Price));
        //    order.Price = totalPrice;
        //}
    }

    public Order CreateOrder(Order order)
    {
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
        return order;
        //order.Id = _orders.Count;
        //_orders.Add(order);
        //return order;
    }

    public Order GetOrderById(int orderId)
    {
        return _dbContext.Orders.First(order => order.Id == orderId);
        //return _orders.FirstOrDefault(order => order.Id == orderId);
    }

    public Order GetOrderByName(string customerName)
    {
        return _dbContext.Orders
            .Where(order => order.IsPaid == false)
            .First(order => order.Customer.Name == customerName);
        //return _orders.FirstOrDefault(order => order.Customer.Name == customerName);
    }

    public List<Order> GetOrders()
    {
        return _dbContext.Orders.ToList();
        //return _orders;
    }

    public Order UpdateOrder(Order order)
    {
        var foundOrder = _dbContext.Orders.First(o => o.Id == order.Id);
        if(foundOrder == null)
        {
            return null;
        }    

        foundOrder = order;
        _dbContext.SaveChanges();
        return foundOrder;
        //var foundOrder = _orders.FirstOrDefault(order => order.Id == order.Id);
        //if (foundOrder != null)
        //{
        //    foundOrder = order;
        //}

        //return foundOrder;
    }
}
