using EternalQuest;

namespace EternalQuest;

public class ChecklistGoal : Goal
{
    private int _target;
    private int _progress;
    private int _bonus;

    public ChecklistGoal(string name, int points, int target, int bonus) : base(name, points)
    {
        _target = target;
        _progress = 0;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _progress++;
        int reward = Points;

        if (_progress == _target)
        {
            reward += _bonus;
            Console.WriteLine($"🎯 {Name} completed! Bonus: {Points}+{_bonus} = {reward} points!");
        }
        else
        {
            Console.WriteLine($"📌 {Name} progress: {_progress}/{_target}. You earned {Points} points.");
        }
    }

    public override string GetDetailsString()
    {
        string status = _progress >= _target ? "X" : " ";
        return $"[{status}] {Name} - Completed {_progress}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Points},{_target},{_progress},{_bonus}";
    }

    public void SetProgress(int progress) => _progress = progress;
}
