class ReflectingActivity : Activity
{
    private List<String> _prompts = new List<String>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<String> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity()
    {
        this.SetActivityName("Reflecting Activity");
        this.SetDescription("This activity will help you reflect on times in your life when you have shown strength and resiliance. This will help you recognize the power you have and how you can use it in other aspects of your life.");
    }
    public void Run()
    {
        string userInput;
        DisplayStartingMessage();
        Console.WriteLine();
        Console.WriteLine("Consider de following Prompt:");
        Console.WriteLine();
        DisplayPrompt();
        Console.WriteLine();         
        do
        {
            Console.WriteLine("When you have something in mind, press enter to continue.");
            userInput = Console.ReadLine();
        } while (userInput != "");
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        DisplayQuestions();
        DisplayEndingMessage();
    }
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, _prompts.Count() - 1);
        string randomPrompt = _prompts[randomIndex];
        return randomPrompt;
    }
    public string GetRandomQuestion()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, _questions.Count() - 1);
        string randomQuestion = _questions[randomIndex];
        _questions.RemoveAt(randomIndex);
        return randomQuestion;
    }
    public void DisplayPrompt()
    {
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
    }
    public void DisplayQuestions()
    {
        for (int i = 0; i < 2; i++)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(GetDuration() / 2);
            Console.WriteLine();
        }
    }
}