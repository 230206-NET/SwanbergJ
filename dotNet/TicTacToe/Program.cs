
Console.WriteLine("TicTacToe");
string[,] board = new string[3, 3];



var dict =
    new Dictionary<string, Tuple<int, int>>{{"1", Tuple.Create(0,0)}, {"2", Tuple.Create(0,1)}, {"3", Tuple.Create(0,2)},
                                            {"4", Tuple.Create(1,0)}, {"5", Tuple.Create(1,1)}, {"6", Tuple.Create(1,2)},
                                            {"7", Tuple.Create(2,0)}, {"8", Tuple.Create(2,1)}, {"9", Tuple.Create(2,2)}};


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

    if (baseBoard.Contains(playerMove))
    {

        MakeMove(playerMove, player);
        player = (player % 2) + 1;

        Console.WriteLine("Player counter is: " + player);
    }
    else
    {
        Console.WriteLine("Invalid Move, Try Again");
    }





}




void MakeMove(string playerMove, int player)
{
    baseBoard = baseBoard.Replace(playerMove, player == 1 ? "X" : "O");
}
