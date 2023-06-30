using System.Diagnostics;
public class Activity
{
    private string _name;
    private string _description;
    static int _spinnerCounter, _duration;
    
    public Activity()
    {
        _spinnerCounter = _duration = 0;
    }
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(5);
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well Done!!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}");
        ShowSpinner(5);
    }
    public void ShowSpinner(int seconds)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds / 1000 < seconds)
        {
            _spinnerCounter++;
            switch (_spinnerCounter % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Thread.Sleep(200);
        }
        Console.Write(" ");
    }
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(string.Format("{0}", i));
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Thread.Sleep(1000);
        }
        Console.Write(" ");
    }
    public void SetActivityName(string activityName)
    {
        _name = activityName;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }

    public int GetDuration()
    {
        return _duration;
    }
}