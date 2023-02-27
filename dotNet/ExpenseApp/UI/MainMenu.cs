using Model;
using Services;
using Microsoft.Data.SqlClient;
using Serilog;

namespace UI;

public class MainMenu
{
    private readonly AccountService _service;

    public MainMenu(AccountService service)
    {
        _service = service;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("Expense Reimbursement App");
            Console.WriteLine("[1]: Login");
            Console.WriteLine("[2]: Create Account");

            string input = Console.ReadLine()!;
            switch (input)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Console.WriteLine("[E]: Create Employee Account");
                    Console.WriteLine("[M]: Create Manager Account");
                    string userType = Console.ReadLine()!;
                    CreateAccount(userType);
                    break;
                default:
                    Console.WriteLine("Please enter a valid option");
                    break;
            }
        }

    }


    private void Login()
    {
        string[] loginInfo = new string[2];
        Console.Write("Username: ");
        loginInfo[0] = Console.ReadLine()!;
        Console.Write("Password: ");
        loginInfo[1] = Console.ReadLine()!;
        try
        {
            Employee user = _service.AuthenticateLogin(loginInfo);
            if (user != null)
            {
                if (user.ManagerID != -1)
                {
                    new EmployeeDisplay(user, _service).Start();
                }
                else
                {
                    new ManagerDisplay(user, _service).Start();
                }
            }
            else
            {
                Console.WriteLine("Unable to login.");
            }
        }
        catch (SqlException ex)
        {
            //Console.WriteLine(ex);
            Log.Error("Login Failed : " + ex);
        }
    }

    private void CreateAccount(string userType)
    {

        int managerID = -1;
        Console.Write("Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Username: ");
        string username = Console.ReadLine()!;
        Console.Write("Password: ");
        string password = Console.ReadLine()!;

        if (userType == "E")
        {
            Console.Write("ManagerID: ");
            managerID = Int32.Parse(Console.ReadLine()!);
        }

        Console.WriteLine("Creating Account. . .");
        Employee user = new Employee
        {
            Name = name,
            Username = username,
            Password = password,
            ManagerID = managerID
        };
        try
        {
            _service.RegisterAccount(user);
            Console.WriteLine("Account successfully created.");
        }
        catch (SqlException ex)
        {
            Log.Error("Creating Account Failed : " + ex);
            //Console.WriteLine(ex);
        }
    }

}