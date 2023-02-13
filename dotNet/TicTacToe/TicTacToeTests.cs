using Xunit;
using TicTacToe;


namespace Tests;

public class TicTacToeTests
{
    [Fact]
    public void InputShouldBeDigit()
    {
        MainMenu tic = new MainMenu();

        Assert.True(tic.IsValidMove("1"));
        Assert.True(tic.IsValidMove("8"));
        Assert.False(tic.IsValidMove("a"));
        Assert.False(tic.IsValidMove("11"));

    }

    [Theory]
    [InlineData("9")]
    public void MakeMoveShouldUpdateBoard(string input)
    {
        MainMenu tic = new MainMenu();
        int[,] testBoard = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 1 } };
        tic.MakeMove(input, 1);
        Assert.Equal(tic.board, testBoard);
    }

    [Theory]
    [InlineData(1)]
    public void IsGameOverShouldBeTrue(int input)
    {
        MainMenu tic = new MainMenu();
        int[,] board = new int[3, 3] { { 1, 1, 1 }, { 0, 0, 0 }, { 0, 0, 0 } };
        tic.board = board;
        Assert.True(tic.IsGameOver(input));
    }

}

