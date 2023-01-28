using App.Models;
using App.Repositories;

namespace App.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerService _customerService;
    private readonly IOrderDetailService _orderDetailService;
    private readonly IMoneyCalculator _moneyCalculator;
    private readonly IRevenueService _revenueService;

    public OrderService(IOrderRepository orderRepository, ICustomerService customerService,
        IOrderDetailService orderDetailService, IMoneyCalculator moneyCalculator,
        IRevenueService revenueService)
    {
        _orderRepository = orderRepository;
        _customerService = customerService;
        _orderDetailService = orderDetailService;
        _moneyCalculator = moneyCalculator;
        _revenueService = revenueService;

        _customerService.CustomerDeleted += OnCustomerDeleted;
    }

    private void OnCustomerDeleted(object sender, string customerName)
    {
        var orders = GetAllOrderByCustomerName(customerName);
        if (orders == null) return;

        foreach (var order in orders)
        {
            order.Customer = null;
        }
    }

    public OrderDetail AddProductToOrder(Order order, Product product)
    {
        var orderDetail = _orderDetailService.AddOrderDetail(order, product);
        order.OrderDetails.Add(orderDetail);
        order.Price = _moneyCalculator.PricePerOrder(order);
        UpdateOrder(order, order.IsMember);
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
        UpdateOrder(order, order.IsMember);
    }

    public Order GetOrderByCustomerName(string customerName)
    {
        return _orderRepository.GetOrderByName(customerName);
    }

    public List<Order> GetOrders()
    {
        return _orderRepository.GetOrders().OrderBy(order => order.Customer?.Name).ToList();
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
            mergedOrder = CreateOrder(new Order() { Customer = customer, OrderDate = DateTime.Now, IsMember = true });
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
                order.Comment += $"Bestelling is samengevoegd in de bestelling van {mergedOrder.Customer?.Name} met ID: {mergedOrder.Id}.\n";
                order.IsFinished = true;
                UpdateOrder(order, mergedOrder.IsMember);
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

            newOrder.Comment += $"Dit is een gesplitste bestelling van {order.Customer?.Name}.\n";
            newOrder.ParentOrder = order;
            CreateOrder(newOrder);
        }

        order.Comment += $"Bestelling is opgesplitst in {newCustomers.Count} bestellingen.\n";
        order.IsFinished = true;
        UpdateOrder(order, order.IsMember);
    }

    public void UpdateOrder(Order order, bool isMember)
    {
        order.IsMember = isMember;
        _orderDetailService.UpdateOrderDetails(order);
        order.Price = _moneyCalculator.PricePerOrder(order);
        _orderRepository.UpdateOrder(order);
    }

    public decimal PayOrder(Order order, decimal amount, PayMethod payMethod)
    {
        decimal remainder = _moneyCalculator.GetRemainderAfterPayment(order, amount);
        var revenue = new Revenue() { Amount = amount, SaleDate = DateTime.Now, PayMethod = payMethod };

        order.PaidAmount += amount;
        order.Price = _moneyCalculator.PricePerOrder(order);

        UpdateOrder(order, order.IsMember);

        if (remainder >= 0)
        {
            _revenueService.AddPayment(revenue);
        }
        else
        {
            amount -= (0 - remainder);
            revenue.Amount = amount;
            _revenueService.AddPayment(revenue);
        }

        return remainder;
    }

    public void FinishOrder(Order order)
    {
        order.IsPaid = true;
        order.IsFinished = true;
        _orderRepository.UpdateOrder(order);
    }

    public List<Order> GetAllOrderByCustomerName(string customerName)
    {
        return _orderRepository.GetOrdersByName(customerName);
    }
}
