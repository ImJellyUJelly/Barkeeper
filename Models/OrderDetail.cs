namespace Models;

public class OrderDetail
{
    public long Id { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
    public DateTime TimeAdded { get; set; }
}
