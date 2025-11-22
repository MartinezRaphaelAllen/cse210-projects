using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menuClass = new Menu();
        bool programRun = true;
        string userInput;
        while (programRun)
        {
            menuClass.DisplayPoints();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Delete Goal");
            Console.WriteLine(" 6. Record Event");
            Console.WriteLine(" 7. Spend Points");
            Console.WriteLine(" 8. Quit");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    {
                        menuClass.CreateNewGoal();
                        break;
                    }
                case "2":
                    {
                        menuClass.DisplayGoal();
                        break;
                    }
                case "3":
                    {
                        menuClass.SaveGoals();
                        break;
                    }
                case "4":
                    {
                        menuClass.LoadGoals();
                        break;
                    }
                case "5":
                    {
                        menuClass.DeleteGoal();
                        break;
                    }
                
                case "6":
                    {
                        menuClass.RecordEvent();
                        break;
                    }
                case "7":
                    {
                        menuClass.SpendPoints();
                        break;
                    }
                case "8":
                    {
                        programRun = false;
                        break;
                    }
            }
        }
    }
}