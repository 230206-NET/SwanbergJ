using Model;
using Services;
using Microsoft.Data.SqlClient;
using Serilog;

namespace UI;

public class ManagerDisplay
{
    private readonly AccountService _service;
    public Employee user;

    public ManagerDisplay(Employee user, AccountService service)
    {
        _service = service;
        this.user = user;
    }
    public void Start()
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
                    ViewPendingTickets();
                    break;
                case "2":
                    ApproveTicket();
                    break;
                case "3":
                    RejectTicket();
                    break;
                case "4":
                    PromoteEmployee();
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

    private void RejectTicket()
    {
        try
        {
            Console.Write("Enter ID of ticket you want to reject: ");
            int ticketID = Int32.Parse(Console.ReadLine()!);
            _service.ChangeTicketStatus(ticketID, Status.Rejected);
            Console.WriteLine("Ticket successfully approved.");
        }
        catch (SqlException ex)
        {
            Log.Error("Error rejecting ticket");
            Console.WriteLine(ex);
        }
    }
    private void PromoteEmployee()
    {
        try
        {
            Console.Write("Enter ID of employee to promote: ");
            int uId = Int32.Parse(Console.ReadLine()!);
            _service.PromoteEmployee(uId);
            Console.WriteLine("Employee successfully promoted.");
        }
        catch (SqlException ex)
        {
            Log.Error("Error promoting employee");
            Console.WriteLine(ex);
        }
    }

    private void ApproveTicket()
    {
        try
        {
            Console.Write("Enter ID of ticket you want to approve: ");
            int ticketID = Int32.Parse(Console.ReadLine()!);
            _service.ChangeTicketStatus(ticketID, Status.Complete);
            Console.WriteLine("Ticket successfully approved.");
        }
        catch (SqlException ex)
        {
            Log.Error("Error approving ticket");
            Console.WriteLine(ex);
        }
    }

    private void ViewPendingTickets()
    {
        try
        {
            Dictionary<string, List<Ticket>> userTickets = _service.GetPendingTickets(user.Id);
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
        catch (SqlException ex)
        {
            Log.Error("Error viewing all tickets in ManagerDisplay : " + ex);
            Console.WriteLine("Couldn't view tickets.");
        }
    }

}