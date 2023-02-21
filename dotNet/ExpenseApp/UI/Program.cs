using UI;
using Services;
using DataAccess;

namespace UI;

public class Program
{
    public static void Main(string[] args)
    {
        new MainMenu(new AccountService(new FileStorage())).Start();
    }
}
