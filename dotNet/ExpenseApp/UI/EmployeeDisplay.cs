using Model;

namespace UI;

public class EmployeeDisplay
{
    private Employee employee { get; set; }
    public EmployeeDisplay(Employee employee)
    {
        this.employee = employee;
    }
    public void Start()
    {
        Console.WriteLine("Welcome back " + employee.Name + "!");
        while (true)
        {
            Console.WriteLine("[1]: View Tickets");
            Console.WriteLine("[2]: Create New Ticket");
            Console.WriteLine("[3]: Edit Pending Ticket");
            string input = Console.ReadLine()!;
            switch (input)
            {
                case "1":
                    ViewTickets();
                    break;
                case "2":
                    CreateNewTicket();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Please Enter A Valid Option");
                    break;
            }
        }

    }

    private void ViewTickets()
    {
        foreach (Ticket t in employee.Tickets)
        {
            Console.WriteLine(t);
        }
    }

    private void CreateNewTicket()
    {
        Console.Write("Expense Type: ");
        string type = Console.ReadLine()!;
        Console.Write("Expense Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Expense Cost: ");
        decimal cost = decimal.Parse(Console.ReadLine()!);
        //Db.AddTicket(type, name, cost, employee)
        employee.Tickets.Add(new Ticket { Type = type, Title = name, Amount = cost });
    }

}