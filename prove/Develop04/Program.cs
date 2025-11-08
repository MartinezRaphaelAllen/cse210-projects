using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity additions:
        // 1.) I've added code that prevents the reflecting activity from displaying the same follow up questions. 
        // It will display a prompt that tells the user that they have extra time to think once all the prompts have been used.
        //
        // 2.) The activity class has additional code that checks the user's input for a valid duration in seconds, it will keep
        // prompting the user until they enter a valid duration of time.

        bool programRun = true;
        string userInput;
        while (programRun)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    {
                        new BreathingActivity();
                        break;
                    }
                case "2":
                    {
                        new ReflectingActivity();
                        break;
                    }
                case "3":
                    {
                        new ListingActivity();
                        break;
                    }
                case "4":
                    {
                        programRun = false;
                        break;
                    }
            }
        }
    }
}