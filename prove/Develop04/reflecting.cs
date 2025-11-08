public class ReflectingActivity : Activity
{

    private Random _randomGenerator = new Random();
    private int _seconds;
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _followUpQuestions = new List<string>()
    {
        "Why was this experience meaningful to you? ",
        "Have you ever done anything like this before? ",
        "How did you get started? ",
        "How did you feel when it was complete? ",
        "What made this time different than other times when you were not successful? ",
        "What is your favorite thing about this experience? ",
        "What could you learn from this experience that applies to other situations? ",
        "What did you learn about yourself through this experience? ",
        "How can you keep this exprience in mind in the future? "
    };
    private List<int> _chosenList = new List<int>();
    public ReflectingActivity()
    {
        _seconds = base.DisplayStartingMessage(2);
        base.DisplayPause();
        DoActivity();
        base.DisplayEndMessage(2, _seconds);
    }
    public void DoActivity()
    {
        int chosenPromptIndex = _randomGenerator.Next(1, 4);

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {_prompts[chosenPromptIndex]} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        //2nd part
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        for (int i = 5; i >= 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        
        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_seconds);
        

        while (DateTime.Now < futureTime)
        {
            if (_chosenList.Count < 9)
            {
                int followUpPromptIndex;
                do
                {
                    followUpPromptIndex = _randomGenerator.Next(0, 9);
                } while (_chosenList.Contains(followUpPromptIndex));

                _chosenList.Add(followUpPromptIndex);
                Console.Write($"{_followUpQuestions[followUpPromptIndex]}");
            }
            else
            {
                Console.Write("--- Extra time to reflect on the previous questions. ---");
            }
            base.DisplayCursorAnimation(10);
            Console.WriteLine();
        }
    }
}