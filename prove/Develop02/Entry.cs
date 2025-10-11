public class Entry
{
    public string _date;
    public string _prompt;
    public string _entryText;
    public List<string> _promptList = new List<string>() { "How have you seen the hand of the Lord today?",
                                                            "Give me an example of how you helped someone today?",
                                                            "If you were given the chance to redo something today, what would it be?",
                                                            "What is the favorite topic you've learned in classes today?",
                                                            "Did you do anything fun or exciting today?"};

    public string ReturnPrompt(List<string> _promptList)
    {
        Random random = new Random();
        int index = random.Next(1, 5);
        string chosenPrompt = _promptList[index];
        return chosenPrompt;
    }

    public string GetDateTime()
    {
        DateTime theCurrentTime = DateTime.Now;
        return theCurrentTime.ToShortDateString();
    }
    public (string response, string prompt, string date) JournalEntry()
    {
        string newPrompt = ReturnPrompt(_promptList);
        string date = GetDateTime();
        Console.WriteLine(newPrompt);
        string userInput = Console.ReadLine();
        Console.WriteLine();
        return (userInput, newPrompt, date);
    }
}