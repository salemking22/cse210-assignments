//Exceeded Requirements by adding gamified feedback using emoji icons for goal types and progress updates. Implemented full Save/Load system using file serialization with custom goal reconstruction. Clean, formatted goal display using checkmarks and progress counters ([X], Completed x/y)Modular and extensible goal structure ready for future features menus, leveling, negative goals. Followed SOLID principles for class design and encapsulation.
using EternalQuest;

namespace EternalQuest;

public class Program
{
    public static void Main()
    {
        GoalManager goalManager = new GoalManager();

        goalManager.LoadGoals("goals.txt");

        goalManager.AddGoal(new SimpleGoal("Run a Marathon", 1000));
        goalManager.AddGoal(new EternalGoal("Read Scriptures", 100));
        goalManager.AddGoal(new ChecklistGoal("Attend Temple", 50, 10, 500));

        goalManager.RecordEvent("Run a Marathon");
        goalManager.RecordEvent("Read Scriptures");
        goalManager.RecordEvent("Attend Temple");

        goalManager.DisplayGoals();

        goalManager.SaveGoals("goals.txt");
    }
}
