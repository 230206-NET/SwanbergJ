namespace BudgetApp;

public class MainMenu
{

    public void Start()
    {
        IDictionary<double, string> expenses = new Dictionary<double, string>();

        Console.WriteLine("Welcome to the Budgeting App!");
        Console.Write("Enter an initial budget: $");

        double budget = double.Parse(Console.ReadLine()!);

        Console.WriteLine();

        Console.WriteLine("Great! Now begin entering expenses and a brief description of each item. Type [quit] to finish.");


        while (budget > 0)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Current Budget: $" + budget);
            Console.Write("\tDecription: ");
            string description = Console.ReadLine()!;
            if (description == "quit")
            {
                break;
            }

            Console.Write("\tCost: $");
            double cost = double.Parse(Console.ReadLine()!);
            budget = Math.Round(budget - cost, 2);
            expenses.Add(cost, description);
        }

        Console.WriteLine("-------------------------------------------------");

        if (budget < 0)
        {
            Console.WriteLine("Oh no! Looks like you're broke :()");
        }

        Console.WriteLine("Expenses List");

        foreach (KeyValuePair<double, string> kvp in expenses)
        {
            Console.WriteLine("\t{1} : ${0}", kvp.Key, kvp.Value);
        }

        Console.WriteLine("Remaining budget: $" + budget);
    }
}



