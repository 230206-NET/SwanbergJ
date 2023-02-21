using Model;
namespace DataAccess;


public interface IRepository
{

    List<Employee> GetAllUsers();

    bool AddNewUser(Employee user);


}