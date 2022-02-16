﻿using API.Repositories;
using Models;

namespace API.Services;

public class OrderService : IOrderService
{
    private IOrderRepository _orderRepository;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _orderRepository = unitOfWork.getOrderRepository();
    }

    public Order CreateOrder(Order order)
    {
        return _orderRepository.CreateOrder(order);
    }

    public Order GetOrderById(int orderId)
    {
        return _orderRepository.GetOrderById(orderId);
    }

    public Order GetOrderByName(string customerName)
    {
        return _orderRepository.GetOrderByName(customerName);
    }

    public List<Order> GetOrders()
    {
        return _orderRepository.GetOrders();
    }

    public Order UpdateOrder(Order order)
    {
        return _orderRepository.UpdateOrder(order);
    }
}
