namespace UI;

using UI;
using Services;
using DataAccess;
using Serilog;




public class Program
{

    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration().WriteTo.File("../logs.txt").CreateLogger();
        try
        {
            Log.Information("Starting Application ... ");
            new MainMenu(new AccountService(new DBRespository())).Start();
        }
        catch (Exception ex)
        {
            Log.Error("Something went horribly wrong " + ex);
        }
        finally
        {
            Log.CloseAndFlush();
        }

    }
}
