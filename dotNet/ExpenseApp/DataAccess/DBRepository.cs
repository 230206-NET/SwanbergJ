//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Model;

namespace DataAccess;

public class DBRespository : IRepository
{
    public List<Employee> GetAllUsers()
    {
        return null;
    }

    public Employee GetUser(string[] info)
    {
        try
        {
            Employee user = new Employee();
            using SqlConnection connection = new SqlConnection(new Secret().GetConnectionString());
            connection.Open();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM UserData WHERE Username = @username AND Password = @pass", connection);
            cmd.Parameters.AddWithValue("@username", info[0]);
            cmd.Parameters.AddWithValue("@pass", info[1]);
            using SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                user.Id = (int)reader[0];
                user.ManagerID = (int)reader[1];
                user.Name = (string)reader[2];
                user.Username = (string)reader[3];
                user.Password = (string)reader[4];
            }
            else
            {
                Console.WriteLine("Invalid login");
                return null;
            }
            return user;

        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

    public List<Ticket> GetTickets(int uId)
    {
        List<Ticket> tickets = new List<Ticket>();
        try
        {
            using SqlConnection connection = new SqlConnection(new Secret().GetConnectionString());
            connection.Open();
            using SqlCommand cmd = new SqlCommand("SELECT Id, Title, Amount, Type, Status, UserId FROM Ticket WHERE Ticket.UserId = @uId AND Ticket.Status = 0", connection);
            cmd.Parameters.AddWithValue("@uId", uId);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ticket tic = new Ticket();
                tic.Id = (int)reader["Id"];
                tic.Amount = (decimal)reader["Amount"];
                tic.Title = (string)reader["Title"];
                tic.Type = (string)reader["Type"];
                tic.Status = (Status)reader["Status"];
                tic.UserId = (int)reader["UserId"];

                tickets.Add(tic);
            }
            return tickets;
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

    public void PromoteEmployee(int uId)
    {
        using SqlConnection connection = new SqlConnection(new Secret().GetConnectionString());
        connection.Open();
        using SqlCommand cmd = new SqlCommand("UPDATE UserData SET ManagerId = -1 WHERE Id = @uId", connection);
        cmd.Parameters.AddWithValue("@uId", uId);
        cmd.ExecuteNonQuery();
    }
    public Dictionary<string, List<Ticket>> GetPendingTickets(int managerId)
    {
        Dictionary<string, List<Ticket>> userTickets = new Dictionary<string, List<Ticket>>();
        try
        {
            using SqlConnection connection = new SqlConnection(new Secret().GetConnectionString());
            connection.Open();
            using SqlCommand cmd = new SqlCommand("SELECT Ticket.Id as tId, Title, Amount, Type, Firstname, UserId FROM Ticket JOIN UserData ON Ticket.UserId = UserData.Id WHERE UserData.ManagerId = @managerId AND Ticket.Status = 0", connection);
            cmd.Parameters.AddWithValue("@managerId", managerId);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string identifier = (string)reader["Firstname"] + "ID: " + (int)reader["UserId"];
                Ticket t = new Ticket()
                {
                    Id = (int)reader["tId"],
                    Title = (string)reader["Title"],
                    Amount = (decimal)reader["Amount"],
                    Type = (string)reader["Type"],
                    Status = Status.Pending,
                };
                if (userTickets.ContainsKey(identifier))
                {
                    userTickets[identifier].Add(t);
                }
                else
                {
                    userTickets.Add(identifier, new List<Ticket>());
                    userTickets[identifier].Add(t);
                }
            }
            return userTickets;
        }
        catch (SqlException ex)
        {
            throw ex;
        }

    }
    public List<Ticket> GetAllTickets(int uId)
    {
        List<Ticket> tickets = new List<Ticket>();
        try
        {
            using SqlConnection connection = new SqlConnection(new Secret().GetConnectionString());
            connection.Open();
            using SqlCommand cmd = new SqlCommand("SELECT Id, Title, Amount, Type, Status, UserId FROM Ticket WHERE Ticket.UserId = @uId", connection);
            cmd.Parameters.AddWithValue("@uId", uId);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ticket tic = new Ticket();
                tic.Id = (int)reader["Id"];
                tic.Amount = (decimal)reader["Amount"];
                tic.Title = (string)reader["Title"];
                tic.Type = (string)reader["Type"];
                tic.Status = (Status)reader["Status"];
                tic.UserId = (int)reader["UserId"];

                tickets.Add(tic);
            }
            return tickets;
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

    public void ChangeTicketStatus(int ticketId, Status status)
    {
        try
        {
            using SqlConnection connection = new SqlConnection(new Secret().GetConnectionString());
            connection.Open();
            using SqlCommand cmd = new SqlCommand("UPDATE Ticket SET Status = @status WHERE Id = @ticketId", connection);
            cmd.Parameters.AddWithValue("@ticketId", ticketId);
            cmd.Parameters.AddWithValue("@status", (int)status);
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

    public void InsertTicket(Ticket tic)
    {

        try
        {
            using SqlConnection connection = new SqlConnection(new Secret().GetConnectionString());
            connection.Open();
            using SqlCommand cmd = new SqlCommand("INSERT INTO Ticket(Title, Amount, Type, Status, UserId) Values (@title, @amt, @type, @status, @uId)", connection);
            cmd.Parameters.AddWithValue("@title", tic.Title);
            cmd.Parameters.AddWithValue("@amt", tic.Amount);
            cmd.Parameters.AddWithValue("@type", tic.Type);
            cmd.Parameters.AddWithValue("@status", tic.Status);
            cmd.Parameters.AddWithValue("@uId", tic.UserId);

            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

    public void AddNewUser(Employee user)
    {
        try
        {
            using SqlConnection connection = new SqlConnection(new Secret().GetConnectionString());
            connection.Open();
            using SqlCommand cmd = new SqlCommand("INSERT INTO UserData(ManagerId, Firstname, Password, Username) Values (@mId, @name, @pass, @user)", connection);
            cmd.Parameters.AddWithValue("@mId", user.ManagerID);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@pass", user.Password);
            cmd.Parameters.AddWithValue("@user", user.Username);

            cmd.ExecuteNonQuery();

        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

}