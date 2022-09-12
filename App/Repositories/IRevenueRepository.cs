using App.Models;

namespace App.Repositories
{
    public interface IRevenueRepository
    {
        void AddPayment(Revenue revenue);
        List<Revenue> GetRevenues();
    }
}
