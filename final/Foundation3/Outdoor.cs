public class Outdoor : Event
{
    private string _weather;
    public Outdoor(string title, string description, string date, string time, string weather) : base(title, description, date, time)
    {
        _weather = weather;
    }
    public override string FullDetails()
    {
        string formulatedString;
        formulatedString = base.FullDetails();
        formulatedString += $"\nWeather Forecast: {_weather}";
        return formulatedString;
    }
}