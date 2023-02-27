using Model;
using Services;
using Microsoft.Data.SqlClient;
using Serilog;

namespace UI;

public class EmployeeDisplay
{
    AccountService _service;
    private Employee employee { get; set; }
    public EmployeeDisplay(Employee employee, AccountService service)
    {
        _service = service;
        this.employee = employee;
    }
    public void Start()
    {
        bool running = true;
        Console.WriteLine("Welcome Back Employee " + employee.Name + "!");
        while (running)
        {
            Console.WriteLine("[1]: View Active Tickets");
            Console.WriteLine("[2]: View All Tickets");
            Console.WriteLine("[3]: Create New Ticket");
            Console.WriteLine("[x]: Logout");
            string input = Console.ReadLine()!;
            switch (input)
            {
                case "1":
                    ViewActiveTickets();
                    break;
                case "2":
                    ViewAllTickets();
                    break;
                case "3":
                    CreateNewTicket();
                    break;
                case "x":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please Enter A Valid Option");
                    break;
            }
        }

    }

    private void ViewActiveTickets()
    {
        try
        {
            List<Ticket> tickets = _service.GetUserTickets(employee.Id);
            if (tickets.Count > 0)
            {
                foreach (Ticket tic in tickets)
                {
                    Console.WriteLine(tic);
                }
            }
            else
            {
                Console.WriteLine("No tickets found");
            }
        }
        catch (SqlException ex)
        {
            Log.Error("Error in trying ViewActiveTickets()");
            throw ex;
        }
    }

    private void ViewAllTickets()
    {
        try
        {
            List<Ticket> tickets = _service.GetAllUserTickets(employee.Id);
            if (tickets != null)
            {
                foreach (Ticket tic in tickets)
                {
                    Console.WriteLine(tic);
                }
            }
            else
            {
                Console.WriteLine("Couldn't find any tickets.");
            }
        }
        catch (SqlException ex)
        {
            Log.Error("Error in trying ViewActiveTickets() : " + ex);
        }
    }
    private void CreateNewTicket()
    {
        Console.Write("Expense Type: ");
        string type = Console.ReadLine()!;
        Console.Write("Expense Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Expense Cost: $");
        decimal cost = decimal.Parse(Console.ReadLine()!);
        Ticket tic = new Ticket()
        {
            Title = name,
            Type = type,
            Amount = cost,
            UserId = employee.Id,
            Status = Status.Pending,
        };
        try
        {
            _service.AddTicket(tic);
        }
        catch (SqlException ex)
        {
            Log.Error("Error creating a new ticket");
            throw ex;
        }
    }

}