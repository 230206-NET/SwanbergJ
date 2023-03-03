
using UI;
using Serilog;



Log.Logger = new LoggerConfiguration().WriteTo.File("../logs.txt").CreateLogger();
try
{
    Log.Information("Starting Application ... ");
    MainMenu menu = new MainMenu();
    await menu.Start();
}
catch (Exception ex)
{
    Log.Error("Something went horribly wrong " + ex);
}
finally
{
    Log.CloseAndFlush();
}