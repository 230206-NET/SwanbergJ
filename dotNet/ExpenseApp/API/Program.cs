using DataAccess;
using Model;
using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IRepository, DBRespository>();
builder.Services.AddScoped<AccountService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");


app.MapGet("/tickets", ([FromQuery] string type, [FromQuery] int uId, [FromServices] AccountService service) =>
{
    switch (type)
    {
        case "all":
            return service.GetAllUserTickets(uId);
        case "active":
            return service.GetUserTickets(uId);
        default:
            return null;
    }
});


app.MapGet("/manager", ([FromQuery] int managerId, [FromServices] AccountService service) =>
{
    return service.GetPendingTickets(managerId);
});

app.MapGet("/login", ([FromQuery] string[] loginInfo, [FromServices] AccountService service) =>
{
    return service.AuthenticateLogin(loginInfo);
});

app.MapPost("/tickets", ([FromBody] Ticket tic, AccountService service) =>
{
    return Results.Created("/tickets", service.AddTicket(tic));
});

app.MapPost("/register", ([FromBody] Employee user, AccountService service) =>
{
    return Results.Created("/register", service.RegisterAccount(user));
});

app.MapPost("/tickets/{ticketId:int}", ([FromRoute] int ticketId, [FromBody] int status, AccountService service) =>
{
    return Results.Created("/register", service.ChangeTicketStatus(ticketId, status));
});

app.MapPost("/manager", ([FromBody] int uId, AccountService service) =>
{
    return Results.Created("/register", service.PromoteEmployee(uId));
});


//POST 

//RegisterAccount(Employee user)

//ChangeTicketStatus(int ticketId, Status status)

//PromoteEmployee(int uId)

//AddTicket(Ticket tic)




app.Run();
