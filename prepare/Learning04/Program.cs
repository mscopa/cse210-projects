using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(a.GetSummary());

        MathAssignment ma = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(ma.GetSummary());
        Console.WriteLine(ma.GetHomeworkList());

        WritingAssignment wa = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(wa.GetSummary());
        Console.WriteLine(wa.GetWritingInformation());
    }
}