public class Running : Activity
{
    private double _distance;

    public Running(string date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }
    public override double CalculateDistance()
    {
        return _distance;
    }
    public override double CalculateSpeed()
    {
        return _distance / base.GetMinutes() * 60;
    }
    public override double CalculatePace()
    {
        return base.GetMinutes() / _distance;
    }

    public override string GetSummary()
    {
        string formatedString;
        formatedString = base.GetSummary();
        formatedString += $"Distance {CalculateDistance()} km, Speed {CalculateSpeed():F2} kph, Pace: {CalculatePace():F2} min per km";

        return formatedString;
    }
}