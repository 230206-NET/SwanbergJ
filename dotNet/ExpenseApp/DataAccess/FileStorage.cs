using Model;
namespace DataAccess;
public class FileStorage : IRepository
{

    public List<Employee> GetAllUsers()
    {

        return null;
    }

    public bool AddNewUser(Employee user)
    {
        //Sql Things happen here
        Console.WriteLine("Creating account of " + user);
        return false;
    }

}
