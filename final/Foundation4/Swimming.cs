public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }
    public override double CalculateDistance()
    {
        return _laps * 50.0 / 1000.0;
    }
    public override double CalculateSpeed()
    {
        return CalculateDistance() / base.GetMinutes() * 60;
    }
    public override double CalculatePace()
    {
        return 60 / CalculateSpeed();
    }
    public override string GetSummary()
    {
        string formatedString;
        formatedString = base.GetSummary();
        formatedString += $"Distance {CalculateDistance()} km, Speed {CalculateSpeed():F2} kph, Pace: {CalculatePace()} min per km";

        return formatedString;
    }
}