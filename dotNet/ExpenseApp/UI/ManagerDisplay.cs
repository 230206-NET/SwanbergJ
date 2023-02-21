using Model;

namespace UI;

public class ManagerDisplay
{
    public Employee user;

    public ManagerDisplay(Employee user)
    {
        this.user = user;
    }
    public void Start()
    {
        Console.WriteLine("Welcome Back " + user.Name + "!");
        Console.WriteLine("[1]: View Pending Tickets");
        Console.WriteLine("[2]: Change Employee Role");
        Console.WriteLine("[3]: View Previous Tickets");
        string input = Console.ReadLine()!;
        switch (input)
        {
            case "1":
                break;
            case "2":
                break;
            case "3":
                break;
            default:
                Console.WriteLine("Enter A Valid Option");
                break;
        }

    }

}