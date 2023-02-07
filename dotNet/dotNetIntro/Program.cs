// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, what's your name?");
String name = Console.ReadLine() ?? throw new ArgumentNullException();
Console.WriteLine("Nice to meet you " + name);