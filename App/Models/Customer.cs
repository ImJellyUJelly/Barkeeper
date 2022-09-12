namespace App.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsMember { get; set; }
    public override string ToString() => Name;
}
