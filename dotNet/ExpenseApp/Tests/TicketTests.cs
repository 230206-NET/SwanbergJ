namespace Tests;
using Model;

public class TicketTests
{
    [Fact]
    public void TicketTitleShouldSet()
    {
        Ticket tic = new();
        tic.Title = "Test";
        Assert.Equal("Test", tic.Title);
    }

    [Fact]
    public void TicketTitleShouldThrowException()
    {
        Ticket tic = new();
        Assert.Throws<ArgumentException>(() => tic.Title = "llllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllll");
    }

    [Fact]
    public void TicketTypeShouldThrowException()
    {
        Ticket tic = new();
        Assert.Throws<ArgumentException>(() => tic.Type = "llllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllll");
    }

    [Fact]
    public void TicketAmountShouldThrowException()
    {
        Ticket tic = new();
        Assert.Throws<ArgumentException>(() => tic.Amount = -1);
    }

    [Fact]
    public void TicketIDShouldThrowException()
    {
        Ticket tic = new();
        Assert.Throws<ArgumentException>(() => tic.Id = 99999);
    }

}