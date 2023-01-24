using App.Models;

namespace App.Repositories
{
    public interface IRevenueRepository
    {
        void AddPayment(Revenue revenue);
        List<Revenue> GetRevenues();
        List<Revenue> GetRevenuesBetweenDates(DateTime startDate, DateTime endDate);
        decimal GetRevenueBetweenDates(DateTime startDate, DateTime endDate);
    }
}
