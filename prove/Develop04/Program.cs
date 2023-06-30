using System;

class Program
{
    static void Main(string[] args)
    {
        int userMenuInput = 0;

        List<String> menu = new List<String>
        {
            "Menu options:",
            "   1. Start Breathing activity.",
            "   2. Start Reflecting activity.",
            "   3. Start Listing activity.",
            "   4. Quit."
        };

        while (userMenuInput != 4)
        {
            Console.Clear();
            foreach (string menuItem in menu)
            {
                Console.WriteLine(menuItem);
            }
            Console.Write("Select a choice from the menu: ");
            userMenuInput = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (userMenuInput)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case 2:
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
            }
        }
    }
}