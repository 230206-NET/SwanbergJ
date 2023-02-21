
namespace Hangman;

public class MainMenu
{

    public void Start()
    {
        Console.WriteLine("HangMan Game");

        string secretWord = "juniper";
        string displayWord = "_______";
        string guess;

        bool IsInputValid(string guess)
        {
            return (!string.IsNullOrWhiteSpace(guess)) && (!int.TryParse(guess, out _)) && guess.Length == 1;
        }

        int guessCount = 6;

        while (guessCount > 0)
        {
            Console.WriteLine("Number of guesses: " + guessCount);
            Console.WriteLine(displayWord);
            Console.WriteLine("Take a guess: ");

            guess = Console.ReadLine()!.ToLower();
            while (!IsInputValid(guess))
            {
                Console.WriteLine("Please enter a valid guess!");
                guess = Console.ReadLine()!.ToLower();
            }
            int idx = secretWord.IndexOf(guess);

            if (idx > -1)
            {
                displayWord = displayWord.Remove(idx, 1).Insert(idx, guess);
            }
            else
            {
                guessCount--;
            }





            if (displayWord == secretWord)
            {
                Console.WriteLine(displayWord);
                Console.WriteLine("You win, Congrats!!!");
                break;

            }
            else if (guessCount == 0)
            {

                Console.WriteLine("You Lose, Too bad");
            }





        }
    }
}

