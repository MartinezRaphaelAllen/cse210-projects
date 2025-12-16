public abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public int GetMinutes()
    {
        return _minutes;
    }
    public abstract double CalculateDistance();

    public abstract double CalculateSpeed();

    public abstract double CalculatePace();

    public virtual string GetSummary()
    {
        return  $"{_date} {GetType()} ({_minutes}): ";
    }
}