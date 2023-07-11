public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
        
    }

public override void RecordEvent()
{
    if (_amountCompleted < _target)
    {
        _amountCompleted++;

        if (_amountCompleted == _target)
        {
            base.SetPoints(_bonus + base.GetPoints());
        }
    }
}
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }
    public override string GetDetailsString()
    {
        string completedStatus = IsComplete() ? "[X]" : "[ ]";
        return $"{completedStatus} {base.GetName()} ({base.GetDescription()}) -- Currently completed: {_amountCompleted}/{_target}";
    }
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal,{base.GetName()},{base.GetDescription()},{base.GetPoints()},{_bonus},{_target},{_amountCompleted}";
    }
}