namespace Models;

public class Order
{
    public long Id { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Price { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }

    public Order()
    {
        OrderDetails = new List<OrderDetail>();
    }

    public Order(long id, string customeName) : this()
    {
        Id = id;
        CustomerName = customeName;
    }
}
