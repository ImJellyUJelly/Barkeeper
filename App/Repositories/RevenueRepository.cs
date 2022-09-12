using App.Contexts;
using App.Models;

namespace App.Repositories
{
    public class RevenueRepository : IRevenueRepository
    {
        private readonly BarkeeperContext _context;
        public RevenueRepository(BarkeeperContext context)
        {
            _context = context;
        }

        public void AddPayment(Revenue revenue)
        {
            _context.Revenues.Add(revenue);
            _context.SaveChanges();
        }

        public List<Revenue> GetRevenues()
        {
            return _context.Revenues.ToList();
        }
    }
}
