using API.Contexts;
using API.Repositories;

namespace API.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly BarkeeperContext _context;

    public UnitOfWork(BarkeeperContext context)
    {
        _context = context;
    }

    public IOrderRepository getOrderRepository()
    {
        return new OrderRepository(_context);
    }
}
