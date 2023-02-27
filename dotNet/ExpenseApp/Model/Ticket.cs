namespace Model;

public enum Status
{
    Pending,
    Rejected,
    Complete
}
public class Ticket
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public Status Status { get; set; }
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public override string ToString()
    {
        string statusString = Enum.GetName(typeof(Status), Status);
        return "Type: " + Type + "\tTicket Name: " + Title + "\tAmount: $" + Amount + "\tTicket ID: " + Id + "\tStatus: " + statusString;
    }
}