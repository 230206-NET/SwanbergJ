using Model;
namespace DataAccess;


public interface IRepository
{

    List<Employee> GetAllUsers();

    void AddNewUser(Employee user);

    void ChangeTicketStatus(int ticketId, Status status);

    Employee GetUser(string[] loginInfo);

    List<Ticket> GetTickets(int uId);

    void PromoteEmployee(int uId);

    List<Ticket> GetAllTickets(int uId);

    Dictionary<string, List<Ticket>> GetPendingTickets(int managerId);

    void InsertTicket(Ticket tic);


}