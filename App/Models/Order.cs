namespace App.Models;

public class Order
{
    public long Id { get; set; }
    public Customer Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Price { get; set; }
    public decimal SplitPrice { get; set; }
    public bool IsMember { get; set; }
    public bool IsPaid { get; set; }
    public bool IsFinished { get; set; }
    public string Comment { get; set; }
    public Order ParentOrder { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }

    public Order()
    {
        OrderDetails = new List<OrderDetail>();
    }

    public override string ToString()
    {
        return Customer.Name;
    }
}
