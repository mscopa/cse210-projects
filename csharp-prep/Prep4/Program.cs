using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        string strNumber;
        int intNumber;
        int suma = 0;
        decimal average;
        int max = 0;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            strNumber = Console.ReadLine();
            intNumber = int.Parse(strNumber);
            numbers.Add(intNumber);
        } while (intNumber != 0);
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
            suma = suma + number;
        }
        average = ((decimal)suma) / (numbers.Count - 1);
        Console.WriteLine($"The sum is: {suma}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The max is: {max}");
    }   
}