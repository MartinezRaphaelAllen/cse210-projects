using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool exitLoop = true;
        while (exitLoop)
        {
            string userInput = journal.DisplayMenu();

            if (userInput is "1" or "2" or "3" or "4" or "5")
            {
                if (userInput == "1")
                {
                    journal.Write();
                }
                else if (userInput == "2")
                {
                    journal.Display();
                }
                else if (userInput == "3")
                {
                    journal.Load();
                }
                else if (userInput == "4")
                {
                    journal.Save();
                }
                else if (userInput == "5")
                {
                    exitLoop = false;
                    Console.WriteLine("Thank you for using the Journal Program, see you again soon!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please type the number of the action you would like to perform.");
                Console.WriteLine();
            }
            

        }


        
    }
}