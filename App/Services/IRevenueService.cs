using App.Models;

namespace App.Services
{
    public interface IRevenueService
    {
        void AddPayment(Revenue revenue);
        List<Revenue> GetRevenues();

        decimal GetRevenueBetweenDates(DateTime startDate, DateTime endDate);
        List<Order> GetPaymentsByTheBoard();
        void InsertSales(List<OrderDetail> orderDetails);
        List<Revenue> GetSalesBetweenDates(DateTime startDate, DateTime endDate);
        List<Revenue> GetRevenuesForFileExport();
    }
}
