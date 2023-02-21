namespace Model;

public class Manager : Employee
{
    public List<Employee> Employees { get; set; }
    public List<Ticket> pendingTickets { get; set; }

}