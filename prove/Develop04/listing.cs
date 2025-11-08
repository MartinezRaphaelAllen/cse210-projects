public class ListingActivity : Activity
{
    private int _seconds;
    private Random _randomGenerator = new Random();
    private List<string> _promptList= new List<string>() {
        "Who are people that you appreciate? ",
        "What are personal strengths of yours? ",
        "Who are people that you have helped this week? ",
        "When have you felt the Holy Ghost this month? ",
        "Who are some of your personal heroes? "
    };
    public ListingActivity()
    {
        _seconds = base.DisplayStartingMessage(3);
        base.DisplayPause();
        DoActivity();
        base.DisplayEndMessage(3, _seconds);
    }

    public void DoActivity()
    {
        int chosenPromptIndex = _randomGenerator.Next(1, 4);
        int listedItems = 0;
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"---{_promptList[chosenPromptIndex]}---");
        Console.Write("You may begin in: ");
        for (int i = 5; i >= 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_seconds);

        while (DateTime.Now < futureTime)
        {
            if (DateTime.Now == futureTime)
            {
                break;
            }
            Console.Write("> ");
            Console.ReadLine();
            listedItems++;
        }
        Console.WriteLine($"You listed {listedItems} items!");
        Console.WriteLine();
    }
}