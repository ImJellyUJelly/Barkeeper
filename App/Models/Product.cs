namespace App.Models;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal EventPrice { get; set; }
    public decimal Price { get; set; }
    public ProductCategory Category { get; set; }
    public bool IsActive { get; set; }
}
