using App.Models;

namespace App.Services
{
    public interface IRevenueService
    {
        void AddPayment(Revenue revenue);
        List<Revenue> GetRevenues();
    }
}
