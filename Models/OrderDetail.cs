namespace Models;

public class OrderDetail
{
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public DateTime TimeAdded { get; set; }
}
