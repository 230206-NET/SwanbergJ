using Model;
namespace DataAccess;


public interface IRepository
{

    List<Employee> GetAllUsers();

    Employee AddNewUser(Employee user);

    bool ChangeTicketStatus(int ticketId, int status);

    Employee GetUser(string[] loginInfo);

    List<Ticket> GetTickets(int uId);

    bool PromoteEmployee(int uId);

    List<Ticket> GetAllTickets(int uId);

    Dictionary<string, List<Ticket>> GetPendingTickets(int managerId);

    Ticket InsertTicket(Ticket tic);


}