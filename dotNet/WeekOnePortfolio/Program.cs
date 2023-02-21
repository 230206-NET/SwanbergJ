using BudgetApp;
using CoinFlipper;
using HotOrCold;
using Hangman;
using TicTacToe;

while (true)
{
    Console.WriteLine("Week One Portfolio \n Pick which program you'd like to run, [q] to quit");
    Console.WriteLine("[1]: BudgetApp");
    Console.WriteLine("[2]: CoinFlipper");
    Console.WriteLine("[3]: HotOrCold");
    Console.WriteLine("[4]: Hangman");
    Console.WriteLine("[5]: TicTacToe");

    string? option = Console.ReadLine();

    switch (option)
    {
        case "1":
            new BudgetApp.MainMenu().Start();
            break;
        case "2":
            new CoinFlipper.MainMenu().Start();
            break;
        case "3":
            new HotOrCold.MainMenu().Start();
            break;
        case "4":
            new Hangman.MainMenu().Start();
            break;
        case "5":
            new TicTacToe.MainMenu().Start();
            break;
        case "q":
            Console.WriteLine("Ending Program...");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid input");
            break;


    }


}