using DataAccess;
using Model;
using Microsoft.Data.SqlClient;
namespace Services;


public class AccountService
{
    private readonly IRepository _repo;

    public AccountService(IRepository repo)
    {
        _repo = repo;
    }

    public Employee RegisterAccount(Employee user)
    {
        try
        {
            return _repo.AddNewUser(user);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

    public List<Ticket> GetUserTickets(int uId)
    {
        try
        {
            return _repo.GetTickets(uId);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

    public bool ChangeTicketStatus(int ticketId, int status)
    {
        try
        {
            return _repo.ChangeTicketStatus(ticketId, status);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

    public bool PromoteEmployee(int uId)
    {
        try
        {
            return _repo.PromoteEmployee(uId);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }
    public Dictionary<string, List<Ticket>> GetPendingTickets(int managerId)
    {

        try
        {
            return _repo.GetPendingTickets(managerId);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

    public List<Ticket> GetAllUserTickets(int uId)
    {
        try
        {
            return _repo.GetAllTickets(uId);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }
    public Ticket AddTicket(Ticket tic)
    {
        try
        {
            return _repo.InsertTicket(tic);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }


    public Employee AuthenticateLogin(string[] loginInfo)
    {
        try
        {
            return _repo.GetUser(loginInfo);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

}
