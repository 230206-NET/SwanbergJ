namespace Model;
using Serilog;
public enum Status
{
    Pending,
    Rejected,
    Complete
}
public class Ticket
{
    private int _id;
    private string _title;
    private string _type;
    private int _userid;
    private decimal _amount;
    public int Id
    {
        get
        {
            return _id;
        }
        set
        {
            if (value > 1000)
            {
                Log.Warning("Ticket Id is too large");
                throw new ArgumentException("Ticket id should be between 0-999");
            }
            else
            {
                _id = value;
            }
        }
    }
    public int UserId
    {
        get
        {
            return _userid;
        }
        set
        {
            if (value > 2000 || value < 1000)
            {
                Log.Warning("UserId is invalid value");
                throw new ArgumentException("User Id should be between 1000-1999");
            }
            else
            {
                _userid = value;
            }
        }
    }
    public Status Status { get; set; }
    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            if (value.Length > 42)
            {
                Log.Warning("Title is too long");
                throw new ArgumentException("Title should be less than 42 characters");
            }
            else
            {
                _title = value;
            }
        }
    }
    public decimal Amount
    {
        get
        {
            return _amount;
        }
        set
        {
            if (value <= 0)
            {
                Log.Warning("Amount cannot be negative");
                throw new ArgumentException("Amount must be greater than 0");
            }
            else
            {
                _amount = value;
            }
        }
    }
    public string Type
    {
        get
        {
            return _type;
        }
        set
        {
            if (value.Length > 25)
            {
                Log.Warning("Type is invalid length");
                throw new ArgumentException("Type must be less than 25 characters");
            }
            else
            {
                _type = value;
            }
        }
    }
    public override string ToString()
    {
        string statusString = Enum.GetName(typeof(Status), Status);
        return "Type: " + Type + "\tTicket Name: " + Title + "\tAmount: $" + Amount + "\tTicket ID: " + Id + "\tStatus: " + statusString;
    }
}