using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int integerSquared = SquareNumber(favoriteNumber);
        DisplayResult(((string)name), ((int)integerSquared));


    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        string number = Console.ReadLine();
        int intNumber = int.Parse(number);
        return intNumber;
    }

    static int SquareNumber(int integer)
    {
        int integerSquared = integer * integer;
        return integerSquared;
    }

    static void DisplayResult(string name, int integerSquared)
    {
        Console.WriteLine($"{name}, the square of your number is {integerSquared}");
    }
}