namespace App.Models;

public class Order
{
    public long Id { get; set; }
    public Customer? Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Price { get; set; }
    public decimal SplitPrice { get; set; }
    public int Coins { get; set; }
    public bool IsPaid { get; set; }
    public bool IsFinished { get; set; }
    public PayMethod PayMethod { get; set; }
    public string Comment { get; set; }
    public Order ParentOrder { get; set; }
    public bool CanPay => !IsFinished && !IsPaid;
    public decimal PaidAmount { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
    public string CustomerName { get; set; }

    public Order()
    {
        OrderDetails = new List<OrderDetail>();
    }

    public string GetName()
    {
        return Customer?.Name ?? CustomerName;
    }
}
