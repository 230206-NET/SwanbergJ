using System.Text.RegularExpressions;


Console.WriteLine("TicTacToe");
int[,] board = new int[3, 3];

string baseBoard =
"""
      |     |     
   1  |  2  |  3                     
 _____|_____|_____
      |     |     
   4  |  5  |  6   
 _____|_____|_____
      |     |     
   7  |  8  |  9  
      |     |     
""";

int player = 1;

while (true)
{
    Console.WriteLine(baseBoard);
    Console.WriteLine("Player " + player + "'s Turn");
    string playerMove = Console.ReadLine()!;
    if (!IsValidMove(playerMove))
    {
        Console.WriteLine("Invalid move, please enter a single digit");
        continue;
    }

    if (baseBoard.Contains(playerMove))
    {

        MakeMove(playerMove, player);
        if (GameOver())
        {
            break;
        }
        player = (player % 2) + 1;

        Console.WriteLine("Player counter is: " + player);
    }
    else
    {
        Console.WriteLine("That spot has already been taken!");
    }
}



void MakeMove(string playerMove, int player)
{
    int move = Int32.Parse(playerMove);
    board[((move - 1) / 3), ((move - 1) % 3)] = player;
    for (int row = 0; row < board.GetLength(0); row++)
    {
        for (int col = 0; col < board.GetLength(1); col++)
        {
            Console.Write(board[row, col] + " ");
        }
        Console.WriteLine();
        Console.WriteLine("-------");
    }
    baseBoard = baseBoard.Replace(playerMove, player == 1 ? "X" : "O");
}

bool IsValidMove(string playerMove)
{
    Regex exp = new Regex(@"^[0-9](?!\d)");
    return exp.Match(playerMove).Success;
}

bool GameOver()
{

    return false;
}
