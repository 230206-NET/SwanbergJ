
namespace DataAccess;

internal class Secret
{

    private string Server = "Server=tcp:swanbergserver.database.windows.net,1433;Initial Catalog=expenseDB;Persist Security Info=False;User ID=john685@revature.net;Password=Iconalar1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=\"Active Directory Password\"";

    public string GetConnectionString()
    {
        return Server;
    }
}