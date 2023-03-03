using Model;
using System.Net.Http;
using System.Net.Http.Json;

using System.Text.Json;

using Serilog;

namespace UI;

public class MainMenu
{
    private readonly HttpClient _http;

    public MainMenu()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:5194/");
    }

    public async Task Start()
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
                    await Login();
                    break;
                case "2":
                    Console.WriteLine("[E]: Create Employee Account");
                    Console.WriteLine("[M]: Create Manager Account");
                    string userType = Console.ReadLine()!;
                    await CreateAccount(userType);
                    break;
                default:
                    Console.WriteLine("Please enter a valid option");
                    break;
            }
        }

    }


    private async Task Login()
    {
        string[] loginInfo = new string[2];
        Console.Write("Username: ");
        loginInfo[0] = Console.ReadLine()!;
        Console.Write("Password: ");
        loginInfo[1] = Console.ReadLine()!;
        try
        {
            // Employee user = _service.AuthenticateLogin(loginInfo);
            string content = await _http.GetStringAsync($"login?loginInfo={loginInfo[0]}&loginInfo={loginInfo[1]}");
            Employee user = JsonSerializer.Deserialize<Employee>(content)!;
            if (user != null)
            {
                if (user.ManagerID != -1)
                {
                    await new EmployeeDisplay(user, _http).Start();
                }
                else
                {
                    await new ManagerDisplay(user, _http).Start();
                }
            }
            else
            {
                Console.WriteLine("Unable to login.");
            }
        }
        catch (Exception ex)
        {
            Log.Error("Login Failed : " + ex);
        }
    }

    private async Task CreateAccount(string userType)
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
            // _service.RegisterAccount(user);
            JsonContent jsonContent = JsonContent.Create<Employee>(user);
            await _http.PostAsync("register", jsonContent);
            Console.WriteLine("Account successfully created.");
        }
        catch (Exception ex)
        {
            Log.Error("Creating Account Failed : " + ex);
            //Console.WriteLine(ex);
        }
    }

}