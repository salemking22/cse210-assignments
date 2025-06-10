namespace EternalQuest;

public abstract class Goal
{
    public string Name;
    public int Points;

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public abstract void RecordEvent();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}
