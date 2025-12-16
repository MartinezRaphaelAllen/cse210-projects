using System.Runtime.InteropServices;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int length, double speed) : base(date, length)
    {
        _speed = speed;
    }

    public override double CalculateDistance()
    {
        return _speed * base.GetMinutes();
    }

    public override double CalculateSpeed()
    {
        return _speed;
    }
    public override double CalculatePace()
    {
        return 60 / _speed;
    }
    public override string GetSummary()
    {
        string formatedString;
        formatedString = base.GetSummary();
        formatedString += $"Distance {CalculateDistance()} km, Speed {CalculateSpeed():F2} kph, Pace: {CalculatePace():F2} min per km";

        return formatedString;
    }
}