namespace Model;
using Serilog;

public class Employee
{
    public Employee()
    {
        Name = "Dummy";
        Username = "Dummy";
        Password = "Dummy";
        Tickets = new List<Ticket>();
    }

    private string _name;
    private string _username;
    private string _password;
    private int _managerid;

    public int Id { get; set; }
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value.Length >= 42)
            {
                Log.Warning("Length of name too long");
                throw new ArgumentException("Name must be less than 42 letters.");
            }
            else
            {
                _name = value;
            }
        }
    }
    public string Username
    {
        get
        {
            return _username;
        }
        set
        {
            if (value.Length > 42)
            {
                Log.Warning("Length of user name too long");
                throw new ArgumentException("Username must be less than 42 letters.");
            }
            else
            {
                _username = value;
            }
        }
    }
    public string Password
    {
        get
        {
            return _password;
        }
        set
        {
            if (value.Length > 42)
            {
                Log.Warning("Length of password too long");
                throw new ArgumentException("Password must be less than 42 letters.");
            }
            else
            {
                _password = value;
            }
        }
    }
    public int ManagerID
    {
        get
        {
            return _managerid;
        }
        set
        {
            if (value > 2000)
            {
                Log.Warning("Invalid manager id");
                throw new ArgumentException("Manager Id must be value from 1000-1999");
            }
            else
            {
                _managerid = value;
            }
        }
    }
    public List<Ticket> Tickets { get; set; }

    public override string ToString()
    {

        return "Name: " + Name + "\nUsername: " + Username
            + "\nPassword: " + Password + "\nManagerId: " + ManagerID;
    }

}
