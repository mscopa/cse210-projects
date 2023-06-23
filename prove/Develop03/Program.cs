using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput;
        Reference reference = new Reference("proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        do
        {
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish.");
            userInput = Console.ReadLine();
            scripture.HideRandomWords(3);
        } while (userInput != "quit");
    }
}