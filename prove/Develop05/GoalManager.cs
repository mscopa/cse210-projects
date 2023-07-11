public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }
    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetName()}");
        }
    }
    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetDetailsString()}");
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points, isComplete: false));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = Convert.ToInt32(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = Convert.ToInt32(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted: 0));
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                CreateGoal();
                break;
        }

        Console.WriteLine("Goal created successfully!");
        Start();
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = Convert.ToInt32(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];

            if (!goal.IsComplete())
            {
                goal.RecordEvent();
                _score += goal.GetPoints();
                Console.WriteLine($"Congratulations! You have earned {goal.GetPoints()} points!");
            }
            else
            {
                Console.WriteLine("Goal has already been completed.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    public void LoadGoals()
    {
        _goals.Clear();

        Console.Write("What is the name of the file? ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);
        _score = Convert.ToInt32(System.IO.File.ReadLines(fileName).First());

        foreach (string line in lines)
        {
            string[] goalParts = line.Split(",");
            
            if (goalParts.Count() <= 1)
            {
                continue;
            }

            string goalType = goalParts[0];
            string name = goalParts[1];
            string description = goalParts[2];
            int points = Convert.ToInt32(goalParts[3]);

            if (goalType == "SimpleGoal")
            {
                bool isComplete = Convert.ToBoolean(goalParts[4]);
                _goals.Add(new SimpleGoal(name, description, points, isComplete));

            }
            else if (goalType == "EternalGoal")
            {
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (goalType == "ChecklistGoal")
            {
                int bonus = Convert.ToInt32(goalParts[4]);
                int target = Convert.ToInt32(goalParts[5]);
                int amountCompleted = Convert.ToInt32(goalParts[6]);

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
            }
        }
    }
}