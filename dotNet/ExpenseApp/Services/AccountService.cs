using DataAccess;
using Model;
namespace Services;


public class AccountService
{
    private readonly IRepository _repo;

    public AccountService(IRepository repo)
    {
        _repo = repo;
    }

    //Maybe throw an error instead? 
    public void RegisterAccount(Employee user)
    {
        if (!_repo.AddNewUser(user))
        {
            Console.WriteLine("There was an error creating this account, please try again.");
        }
        Console.WriteLine("Account created successfully.");
    }

    public Employee AuthenticateLogin(string[] loginInfo)
    {

        //Talk to the db and create an employee object here

        return null;
    }

}
