using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string choice = "1";
        // do
        // {
        //     Entry entry = new Entry();
        //     entry._promptText = promptGenerator.GetRandomPrompt();
        //     Console.Write(entry._promptText);
        //     entry._entryText = Console.ReadLine();
        //     Console.Write("Enter the date: ");        
        //     entry._date = Console.ReadLine();
        //     journal.AddEntry(entry);
        //     Console.Write("Would you like to add another entry? ");
        //     decision = Console.ReadLine();
        // } while (decision != "no");
        // journal.DisplayAll();
        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Convert to Json");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                Entry entry = new Entry();
                entry._promptText = new PromptGenerator().GetRandomPrompt();
                Console.WriteLine(entry._promptText);
                Console.Write("> ");
                entry._entryText = Console.ReadLine();
                entry._date = DateTime.Now.Date.ToString("MMM dd, yyyy");
                journal.AddEntry(entry);

            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.WriteLine("What is the filename?");
                string file = Console.ReadLine();
                journal.LoadToFile(file);
            }
            else if (choice == "4")
            {
                Console.WriteLine("What is the filename?");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }
            else if (choice == "5")
            {
                
            }
            else if (choice == "6")
            {
                Console.WriteLine("What is the filename?");
                string file = Console.ReadLine();
                journal.ConvertToJson(file);
            }
            else
            {
                Console.WriteLine("Select a number between 1-5.");
            }
        }
    }
}