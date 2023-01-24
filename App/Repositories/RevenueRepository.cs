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

        public decimal GetRevenueBetweenDates(DateTime startDate, DateTime endDate)
        {
            try
            {
                return _context.Revenues
                    .Where(revenue => revenue.SaleDate >= startDate)
                    .Where(revnue => revnue.SaleDate < endDate)
                    .Sum(revenue => revenue.Amount);
            }
            catch (Exception)
            {
                return 0M;
            }
        }

        public List<Revenue> GetRevenues()
        {
            return _context.Revenues.ToList();
        }

        public List<Revenue> GetRevenuesBetweenDates(DateTime startDate, DateTime endDate)
        {
            return _context.Revenues.Where(rev => rev.SaleDate >= startDate)
                .Where(rev => rev.SaleDate < endDate)
                .ToList();
        }
    }
}
