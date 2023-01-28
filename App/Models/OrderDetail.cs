namespace App.Models;

public class OrderDetail
{
    public long Id { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
    public DateTime TimeAdded { get; set; }
    public decimal Price { get; set; }
    public int Coins { get; set; }
}
