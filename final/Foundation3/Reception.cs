public class Reception : Event
{
    private string _email;
    private string _RSVP;
    public Reception(string title, string description, string date, string time, string email, bool RSVP) : base(title, description, date, time)
    {
        _email = email;
        _RSVP = CheckRSVP(RSVP);
    }

    public string CheckRSVP(bool RSVP)
    {
        if (RSVP)
            return "Yes";
        else
            return "No";
    }
    public override string FullDetails()
    {
        string formulatedString;
        formulatedString = base.FullDetails();
        formulatedString += $"\nEmail: {_email}\nRSVP: {_RSVP}";
        return formulatedString;
    }
}