﻿using App.Contexts;
using App.Repositories;

namespace App.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly BarkeeperContext _context;

    public UnitOfWork(BarkeeperContext context)
    {
        _context = context;
    }

    public IOrderRepository getOrderRepository()
    {
        return new OrderRepository(_context, GetProductRepository());
    }

    public IProductRepository GetProductRepository()
    {
        return new ProductRepository(_context);
    }
}