// See https://aka.ms/new-console-template for more information

using System;

namespace CoinFlipper
{

    public class Flipper
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Coin Flipper starting ...");
            var rand = new Random();
            bool heads = true;
            String side = "Head";
            int val = rand.Next();

            if (val % 2 > 0)
            {
                heads = false;
                side = "Tails";
            }

            Console.WriteLine("It was " + side + "!");



        }
    }

}

