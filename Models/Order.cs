namespace Models;

public class Order
{
    public int Id { get; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public List<Product> Products { get; set; }

    public Order()
    {
        Products = new List<Product>();
    }

    public Order(int id, string customeName) : this()
    {
        Id = id;
        CustomerName = customeName;
    }
}
