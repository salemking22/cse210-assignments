using System;
using System.Collections.Generic;
using System.IO;
using EternalQuest;

namespace EternalQuest;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
        Console.WriteLine($"➕ New goal added: {goal.GetDetailsString()}");
    }

    public void RecordEvent(string goalName)
    {
        foreach (Goal goal in _goals)
        {
            if (goal.Name == goalName)
            {
                goal.RecordEvent();
                _score += goal.Points;
                return;
            }
        }
        Console.WriteLine("⚠ Goal not found.");
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\n📋 Your Goals:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
        Console.WriteLine($"🌟 Total Score: {_score}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("💾 Goals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("❌ File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        foreach (string line in lines[1..])
        {
            string[] parts = line.Split(":");
            string type = parts[0];
            string[] data = parts[1].Split(',');

            if (type == "SimpleGoal")
            {
                var g = new SimpleGoal(data[0], int.Parse(data[1]));
                g.MarkComplete(bool.Parse(data[2]));
                _goals.Add(g);
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(data[0], int.Parse(data[1])));
            }
            else if (type == "ChecklistGoal")
            {
                var g = new ChecklistGoal(data[0], int.Parse(data[1]),
                                          int.Parse(data[2]), int.Parse(data[4]));
                g.SetProgress(int.Parse(data[3]));
                _goals.Add(g);
            }
        }

        Console.WriteLine("📂 Goals loaded successfully.");
    }
}
