namespace App.Models;

public class Session
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public string GetStartDate()
    {
        return $"{StartDate.ToShortDateString()} - {StartDate.ToShortTimeString()}";
    }

    public string GetEndDate()
    {
        if (EndDate is null)
        {
            return "";
        }

        return $"{EndDate?.ToShortDateString()} - {EndDate?.ToShortTimeString()}";
    }
}