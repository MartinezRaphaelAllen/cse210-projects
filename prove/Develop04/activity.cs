using System.Linq.Expressions;

public class Activity
{
    private int _duration;
    private List<string> _activityList = new List<string>() {"Breathing", "Reflecting", "Listing"};
    private List<string> _startingMessage = new List<string>()
    {
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    };
    public int DisplayStartingMessage(int type)
    {
        // Each type corresponds to the respective activity, 1 = breathing, 2 = Reflecting, 3 = Listing. 
        // Type's original value is decreased by one to match the index number in _activityList.
        type -= 1;
        Console.Clear();
        Console.WriteLine($"Welocome to the {_activityList[type]} Activity.");
        Console.WriteLine();
        Console.WriteLine(_startingMessage[type]);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        while (!int.TryParse(Console.ReadLine(), out _duration))
        {
            Console.WriteLine("Invalid input. Please only enter valid numbers: ");
        }
        return _duration;
    }

    public void DisplayEndMessage(int type, int seconds)
    {
        type -= 1;
        Console.WriteLine();
        Console.WriteLine("Well Done!!");
        DisplayCursorAnimation(5);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {seconds} seconds of the {_activityList[type]} Activity.");
        DisplayCursorAnimation(5);
    }
    public void DisplayCursorAnimation(int seconds)
    {
        Console.CursorVisible = false;
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }
    public void DisplayPause()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        DisplayCursorAnimation(5);
        Console.WriteLine();
    }
}