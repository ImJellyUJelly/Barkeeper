using App.Models;
using App.Repositories;

namespace App.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerService _customerService;
    private readonly IOrderDetailService _orderDetailService;
    private readonly IMoneyCalculator _moneyCalculator;

    public OrderService(IOrderRepository orderRepository, ICustomerService customerService,
        IOrderDetailService orderDetailService, IMoneyCalculator moneyCalculator)
    {
        _orderRepository = orderRepository;
        _customerService = customerService;
        _orderDetailService = orderDetailService;
        _moneyCalculator = moneyCalculator;
    }

    public OrderDetail AddProductToOrder(Order order, Product product)
    {
        var orderDetail = new OrderDetail() { Order = order, Product = product, TimeAdded = DateTime.Now };
        order.OrderDetails.Add(orderDetail);
        order.Price = _moneyCalculator.PricePerOrder(order);
        UpdateOrder(order);
        return orderDetail;
    }

    public Order CreateOrder(Order order)
    {
        order.OrderDate = DateTime.Now;
        order.Price = _moneyCalculator.PricePerOrder(order);
        return _orderRepository.CreateOrder(order);
    }

    public void DeleteProductFromOrder(Order order, OrderDetail orderDetail)
    {
        _orderDetailService.RemoveOrderDetail(orderDetail);
        order.OrderDetails.Remove(orderDetail);
        order.Price = _moneyCalculator.PricePerOrder(order);
        UpdateOrder(order);
    }

    public Order GetOrderByCustomerName(string customerName)
    {
        return _orderRepository.GetOrderByName(customerName);
    }

    public List<Order> GetOrders()
    {
        return _orderRepository.GetOrders().OrderBy(order => order.Customer.Name).ToList();
    }

    public List<Order> GetUnFinishedAndUnPaidOrders()
    {
        return _orderRepository.GetOrders().Where(order => order.IsFinished == false && order.IsPaid == false).ToList(); ;
    }

    public void MergeOrders(List<Order> orderList, string customerName)
    {
        Customer customer = _customerService.FindOrCreateCustomer(customerName);
        Order mergedOrder = GetOrderByCustomerName(customer.Name);
        if (mergedOrder == null)
        {
            mergedOrder = new Order() { Customer = customer, OrderDate = DateTime.Now, IsMember = true };
            mergedOrder = CreateOrder(mergedOrder);
        }
        else
        {
            mergedOrder.Comment += "Deze bestelling is samengevoegd uit ID's: ";
            foreach (var order in orderList)
            {
                mergedOrder.Comment += $"{order.Id} ";
                foreach (var orderDetail in order.OrderDetails)
                {
                    AddProductToOrder(mergedOrder, orderDetail.Product);
                }
            }

            mergedOrder.Comment += "\n";
            mergedOrder.Price = _moneyCalculator.PriceForMergedOrder(orderList);
            mergedOrder.SplitPrice = _moneyCalculator.SplitPriceForMergedOrder(orderList);
            foreach (var order in orderList)
            {
                order.Comment += $"Bestelling is samengevoegd in de bestelling van {mergedOrder.Customer.Name} met ID: {mergedOrder.Id}.\n";
                order.IsFinished = true;
                UpdateOrder(order);
            }
        }
    }

    public void SplitOrder(Order order, Dictionary<string, decimal> newCustomers)
    {
        decimal splitPrice = _moneyCalculator.PricePerSplitOrder(order, newCustomers.Count);
        foreach (var item in newCustomers)
        {
            Order newOrder = GetOrderByCustomerName(item.Key);
            if (newOrder == null)
            {
                newOrder = new Order() 
                { 
                    OrderDate = DateTime.Now, 
                    Customer = _customerService.FindOrCreateCustomer(item.Key), 
                    SplitPrice = splitPrice
                };
            }

            newOrder.Comment += $"Dit is een gesplitste bestelling van {order.Customer.Name}.\n";
            newOrder.ParentOrder = order;
            CreateOrder(newOrder);
        }

        order.Comment += $"Bestelling is opgesplitst in {newCustomers.Count} bestellingen.\n";
        order.IsFinished = true;
        UpdateOrder(order);
    }

    public void UpdateOrder(Order order)
    {
        _orderRepository.UpdateOrder(order);
    }

    public void PayOrder(Order order, decimal amount)
    {
        order.IsPaid = true;
        order.IsFinished = true;
        _orderRepository.UpdateOrder(order);
    }
}
