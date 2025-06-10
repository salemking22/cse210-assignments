using EternalQuest;

namespace EternalQuest;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, int points) : base(name, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"✔ {Name} completed! You earned {Points} points.");
        }
        else
        {
            Console.WriteLine($"⚠ {Name} is already complete.");
        }
    }

    public override string GetDetailsString()
    {
        return _isComplete ? $"[X] {Name} - {Points} points" : $"[ ] {Name} - {Points} points";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Points},{_isComplete}";
    }

    public void MarkComplete(bool complete) => _isComplete = complete;
}
