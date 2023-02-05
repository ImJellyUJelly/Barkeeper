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
                    .Where(revenue => revenue.SaleDate < endDate)
                    .Where(revenue => revenue.PayMethod != PayMethod.None)
                    .Where(revenue => revenue.PayMethod != PayMethod.Coins)
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
            try
            {
                return _context.Revenues
                .Where(revenue => revenue.SaleDate >= startDate)
                .Where(revenue => revenue.SaleDate < endDate)
                .Where(revenue => revenue.PayMethod != PayMethod.None)
                .Where(revenue => revenue.PayMethod != PayMethod.Coins)
                .ToList();
            }
            catch (Exception)
            {
                return new List<Revenue>();
            }
        }
    }
}
