public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50.0 / 1000; // km

    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;

    public override double GetPace() => GetMinutes() / GetDistance();
}
