using EternalQuest;

namespace EternalQuest;

public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"🔄 {Name} recorded! You earned {Points} points.");
    }

    public override string GetDetailsString()
    {
        return $"🔄 {Name} - {Points} points";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Points}";
    }
}
