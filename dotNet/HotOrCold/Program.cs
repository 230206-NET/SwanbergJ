using System;

namespace HotOrCold
{

    public class MainMenu
    {

        public void Start()
        {
            var rand = new Random();
            int target = rand.Next(20);
            int userInput = -1;

            Console.WriteLine("Welcome to Hot or Cold! Try to guess a number 0 - 20!");
            while (userInput != target)
            {
                userInput = Int32.Parse(Console.ReadLine());
                if (userInput < target)
                {
                    Console.WriteLine("Too Cold! Try Again");
                }
                if (userInput > target)
                {
                    Console.WriteLine("Too Hot! Try Again");
                }
            }

            Console.WriteLine("Congratulations! The number was " + target + ". Thanks for playing!");



        }

    }
}
