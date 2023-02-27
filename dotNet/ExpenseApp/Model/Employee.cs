namespace Model;

public class Employee
{
    public Employee()
    {
        Name = "Dummy";
        Username = "Dummy";
        Password = "Dummy";
        Tickets = new List<Ticket>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int ManagerID { get; set; }
    public List<Ticket> Tickets { get; set; }

    public override string ToString()
    {

        return "Name: " + Name + "\nUsername: " + Username
            + "\nPassword: " + Password + "\nManagerId: " + ManagerID;
    }

}
