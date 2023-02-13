using System.Text.RegularExpressions;

namespace TicTacToe;

public class MainMenu
{

    public void Start()
    {
        Console.WriteLine("TicTacToe");
        int[,] board = new int[3, 3];

        string baseBoard =
        """
            |     |     
         1  |  2  |  3  
        ____|_____|_____
            |     |     
         4  |  5  |  6  
        ____|_____|_____
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
                if (!baseBoard.Any(c => char.IsDigit(c)))
                {
                    Console.WriteLine("You tied the game");
                    break;
                }
                if (IsGameOver(player))
                {
                    Console.WriteLine(baseBoard);
                    Console.WriteLine("Player " + player + " won the game");
                    break;
                }
                player = (player % 2) + 1;
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
            baseBoard = baseBoard.Replace(playerMove, player == 1 ? "X" : "O");
        }

        bool IsValidMove(string playerMove)
        {
            Regex exp = new Regex(@"^[0-9](?!\d)");
            return exp.Match(playerMove).Success;
        }

        bool IsGameOver(int player)
        {
            //player = 1 or 2
            //Check rows
            //board[row, 0] => [1,2,0]
            //board[row, 1] => [1,1,2]
            //board[row, 2] => [1,1,1]
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(0); col++)
                {
                    if (board[row, col] != (player))
                    {
                        break;
                    }
                    if (col == board.GetLength(0) - 1)
                    {
                        return true;
                    }
                }
            }

            //Check cols
            //board[0, 0] => [1,1,1]
            //board[1, 0] => [2,1,1]
            //board[2, 0] => [0,2,1]
            for (int col = 0; col < board.GetLength(0); col++)
            {
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    if (board[row, col] != (player))
                    {
                        break;
                    }
                    if (row == (board.GetLength(0) - 1))
                    {
                        return true;
                    }
                }
            }
            //Check diagonal
            if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            || (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
            {
                return true;
            }

            return false;
        }
    }
}

