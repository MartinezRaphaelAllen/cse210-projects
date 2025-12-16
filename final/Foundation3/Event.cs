using System.Net.Sockets;

public class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    public Event(string title, string description, string date, string time)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
    }

    public void SetAddress(string streetAddress, string city, string state, string country)
    {
        _address = new Address(streetAddress, city, state, country);
    }

    public string StandardDetails()
    {
        return $"Title: {_title}\nDesription: {_description}\nDate: {_date}\nTime: {_time}\nAddress: {_address.FullAddress()}";
    }

    public virtual string FullDetails()
    {
        return $"Title: {_title}\nDesription: {_description}\nDate: {_date}\nTime: {_time}\nAddress: {_address.FullAddress()}";
    }

    public string ShortDescription()
    {
        return $"Event: {GetType()}\nTitle: {_title}\nDate: {_date}";
    }
}