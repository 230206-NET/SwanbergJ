namespace Tests;
using Model;

public class EmployeeTests
{

    [Fact]
    public void EmployeeNameShouldSet()
    {
        Employee e = new();
        e.Name = "Test";
        Assert.Equivalent("Test", e.Name);
    }

    [Fact]
    public void EmployeeNameLengthShouldThrowException()
    {
        Employee e = new();
        Assert.Throws<ArgumentException>(() => e.Name = "llllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllll");
    }

    [Fact]
    public void EmployeePasswordLengthShouldThrowException()
    {
        Employee e = new();
        Assert.Throws<ArgumentException>(() => e.Password = "llllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllll");
    }


    [Fact]
    public void EmployeeUsernameLengthShouldThrowException()
    {
        Employee e = new Employee();
        Assert.Throws<ArgumentException>(() => e.Username = "llllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllll");
    }

    [Fact]
    public void EmployeeManagerIdShouldThrowException()
    {
        Employee e = new Employee();
        Assert.Throws<ArgumentException>(() => e.ManagerID = 3000);
    }




}