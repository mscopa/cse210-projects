public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "Is there someone you never properly thanked? How might you express your gratitude? ",
        "What are all the things you're grateful for today? ",
        "What are three good things about today? ",
        "Who would you like to have a stronger relationship with and what might you do to grow that relationship? ",
        "How do you relate to others? How might you relate to others in ways that better serve you and them? ",
        "What are the things you could do today to start moving towards your goals? ",
        "What do you love and hate about yourself today? Why? ",
    };
    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(0, _prompts.Count() - 1);
        return _prompts[number];
    }
}