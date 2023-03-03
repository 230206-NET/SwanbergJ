using Model;
using Serilog;
using System.Net.Http.Json;

using System.Text.Json;

namespace UI;

public class ManagerDisplay
{
    public Employee user;
    private readonly HttpClient _http;

    public ManagerDisplay(Employee user, HttpClient http)
    {
        _http = http;
        this.user = user;
    }
    public async Task Start()
    {
        Console.WriteLine("Welcome Back Manager " + user.Name + "!");
        bool running = true;
        while (running)
        {
            Console.WriteLine("[1]: View Pending Tickets");
            Console.WriteLine("[2]: Approve Ticket");
            Console.WriteLine("[3]: Reject Ticket");
            Console.WriteLine("[4]: Change Employee Role");
            Console.WriteLine("[x]: Logout");
            string input = Console.ReadLine()!;
            switch (input)
            {
                case "1":
                    await ViewPendingTickets();
                    break;
                case "2":
                    await ApproveTicket();
                    break;
                case "3":
                    await RejectTicket();
                    break;
                case "4":
                    await PromoteEmployee();
                    break;
                case "x":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Enter A Valid Option");
                    break;
            }
        }

    }

    private async Task RejectTicket()
    {
        try
        {
            Console.Write("Enter ID of ticket you want to reject: ");
            int ticketID = Int32.Parse(Console.ReadLine()!);

            JsonContent jsonContent = JsonContent.Create<int>(2);
            await _http.PostAsync($"tickets/{ticketID}", jsonContent);
            // _service.ChangeTicketStatus(ticketID, 2);
            Console.WriteLine("Ticket successfully approved.");
        }
        catch (Exception ex)
        {
            Log.Error("Error rejecting ticket");
            Console.WriteLine(ex);
        }
    }
    private async Task PromoteEmployee()
    {
        try
        {
            Console.Write("Enter ID of employee to promote: ");
            int uId = Int32.Parse(Console.ReadLine()!);

            JsonContent jsonContent = JsonContent.Create<int>(uId);
            await _http.PostAsync("manager", jsonContent);
            // _service.PromoteEmployee(uId);
            Console.WriteLine("Employee successfully promoted.");
        }
        catch (Exception ex)
        {
            Log.Error("Error promoting employee");
            Console.WriteLine(ex);
        }
    }

    private async Task ApproveTicket()
    {
        try
        {
            Console.Write("Enter ID of ticket you want to approve: ");
            int ticketID = Int32.Parse(Console.ReadLine()!);

            JsonContent jsonContent = JsonContent.Create<int>(2);
            await _http.PostAsync($"tickets/{ticketID}", jsonContent);
            Console.WriteLine("Ticket successfully approved.");
        }
        catch (Exception ex)
        {
            Log.Error("Error approving ticket");
            Console.WriteLine(ex);
        }
    }

    private async Task ViewPendingTickets()
    {
        try
        {
            // Dictionary<string, List<Ticket>> userTickets = _service.GetPendingTickets(user.Id);
            string content = await _http.GetStringAsync($"manager?managerId={user.Id}");
            Dictionary<string, List<Ticket>> userTickets = JsonSerializer.Deserialize<Dictionary<string, List<Ticket>>>(content)!;

            if (userTickets.Count > 0)
            {
                foreach (string user in userTickets.Keys)
                {
                    Console.WriteLine(user);
                    foreach (Ticket t in userTickets[user])
                    {
                        Console.WriteLine("\t" + t);
                    }
                }
            }
            else
            {
                Console.WriteLine("Couldn't find any tickets.");
            }
        }
        catch (Exception ex)
        {
            Log.Error("Error viewing all tickets in ManagerDisplay : " + ex);
            Console.WriteLine("Couldn't view tickets.");
        }
    }

}