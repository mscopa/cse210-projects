class ListingActivity : Activity
{
    private int _count;
    private List<String> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        this.SetActivityName("Listing Activity");
        this.SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }
    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        
        Console.WriteLine();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetDuration());
        do
        {
            Console.Write("> ");
            Console.ReadLine();
            startTime = DateTime.Now;
            _count++;
        } while (startTime < futureTime);
        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, _prompts.Count() - 1);
        string randomPrompt = _prompts[randomIndex];
        return randomPrompt;
    }
    public List<String> GetListFromUser()
    {
        return _prompts;
    }
}