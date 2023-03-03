using Model;
using System.Net.Http.Json;

using System.Text.Json;
using Serilog;

namespace UI;

public class EmployeeDisplay
{
    private readonly HttpClient _http;

    private Employee employee { get; set; }
    public EmployeeDisplay(Employee employee, HttpClient http)
    {
        _http = http;
        this.employee = employee;
    }
    public async Task Start()
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
                    await ViewActiveTickets();
                    break;
                case "2":
                    await ViewAllTickets();
                    break;
                case "3":
                    await CreateNewTicket();
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

    private async Task ViewActiveTickets()
    {
        try
        {
            string content = await _http.GetStringAsync($"tickets?type=active&uId={employee.Id}");
            List<Ticket> tickets = JsonSerializer.Deserialize<List<Ticket>>(content)!;
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
        catch (Exception ex)
        {
            Log.Error("Error in trying ViewActiveTickets()");
            throw ex;
        }
    }

    private async Task ViewAllTickets()
    {
        try
        {
            string content = await _http.GetStringAsync($"tickets?type=all&uId={employee.Id}");
            List<Ticket> tickets = JsonSerializer.Deserialize<List<Ticket>>(content)!;
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
        catch (Exception ex)
        {
            Log.Error("Error in trying ViewActiveTickets() : " + ex);
        }
    }
    private async Task CreateNewTicket()
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
            // _service.AddTicket(tic);
            JsonContent jsonContent = JsonContent.Create<Ticket>(tic);
            await _http.PostAsync("tickets", jsonContent);
        }
        catch (Exception ex)
        {
            Log.Error("Error creating a new ticket");
            throw ex;
        }
    }

}