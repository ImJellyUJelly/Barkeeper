using App.Contexts;
using App.Repositories;

namespace App.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly BarkeeperContext _context;

    public UnitOfWork(BarkeeperContext context)
    {
        _context = context;
    }

    public IOrderRepository GetOrderRepository()
    {
        return new OrderRepository(_context, GetProductRepository());
    }

    public IProductRepository GetProductRepository()
    {
        return new ProductRepository(_context);
    }

    public IMemberRepository GetMemberRepository()
    {
        return new MemberRepository(_context);
    }
}
