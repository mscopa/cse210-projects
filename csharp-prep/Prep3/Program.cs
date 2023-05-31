using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);
        string guess;
        int guessNumber;
        do
        {
            Console.Write("What is your guess? ");
            guess = Console.ReadLine();
            guessNumber = int.Parse(guess);
            if (guessNumber > number)
            {
                Console.WriteLine("Lower.");
            }
            else if (guessNumber < number)
            {
                Console.WriteLine("Higher.");
            }
        } while (guessNumber != number);
        Console.Write("You guessed it!");
    }
}