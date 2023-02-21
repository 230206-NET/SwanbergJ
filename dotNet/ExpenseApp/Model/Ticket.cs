namespace Model;

public enum Status
{
    Pending,
    Rejected,
    Complete
}
public class Ticket
{
    public Status Status { get; set; }
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public override string ToString()
    {
        return "Ticket Name: " + Title + " Type: " + Type + " Amount: $" + Amount;
    }
}