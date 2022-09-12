using App.Models;
using App.Repositories;

namespace App.Services
{
    internal class RevenueService : IRevenueService
    {
        private readonly IRevenueRepository _revenueRepository;
        public RevenueService(IRevenueRepository revenueRepository)
        {
            _revenueRepository = revenueRepository;
        }

        public void AddPayment(Revenue revenue)
        {
            _revenueRepository.AddPayment(revenue);
        }

        public List<Revenue> GetRevenues()
        {
            return _revenueRepository.GetRevenues();
        }
    }
}
