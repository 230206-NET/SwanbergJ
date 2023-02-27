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

    public void RegisterAccount(Employee user)
    {
        try
        {
            _repo.AddNewUser(user);
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

    public void ChangeTicketStatus(int ticketId, Status status)
    {
        try
        {
            _repo.ChangeTicketStatus(ticketId, status);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

    public void PromoteEmployee(int uId)
    {
        try
        {
            _repo.PromoteEmployee(uId);
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
    public void AddTicket(Ticket tic)
    {
        try
        {
            _repo.InsertTicket(tic);
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
