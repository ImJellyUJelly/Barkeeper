namespace App.Models;

public class Session
{
    public int Id { get; set; }
    public bool IsEvent { get; set; }
    public DateTime EventDate { get; set; }
}