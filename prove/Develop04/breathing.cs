public class BreathingActivity : Activity
{
    private int _seconds;
    public BreathingActivity()
    {
        _seconds = base.DisplayStartingMessage(1);
        base.DisplayPause();
        DoActivity();
        base.DisplayEndMessage(1, _seconds);
    }
    public void DoActivity()
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_seconds);

        while (DateTime.Now < futureTime)
        {
            Console.WriteLine();
            Console.Write("Breath in...");
            for (int i = 5; i >= 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
            Console.Write("Breath out...");
            for (int i = 5; i >= 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }
    }
}