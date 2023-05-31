using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Type your grade percentage: ");
        string letterGrade = Console.ReadLine();
        int number = int.Parse(letterGrade);
        string letter;
        if (number >= 70 && number <= 100)
        {
            if (number >= 90)
            {
                letter = "A";
            }
            else if (number >= 80)
            {
                letter = "B";
            }
            else
            {
                letter = "C";
            }
            Console.WriteLine($"Congrats! Your grade is {letter}. You approve the subject.");
        }
        else if (number < 70 && number >= 0)
        {
            if (number >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }
            Console.WriteLine($"Your grade is {letter}. You disapproved but you'll do better next time!");
        }
        else
        {
            Console.Write("Enter a valid number. Your grade needs to be between 0 and 100, strings are not allowed.");
        }
    }
}