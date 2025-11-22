using System.Runtime.InteropServices.Marshalling;
using System.IO;
public class Menu
{
    private List<Goal> _goals = new List<Goal>();
    private int _accumulatedPoints = 0;

    public Menu()
    {   
    }

    public void DisplayPoints()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_accumulatedPoints} points");
        Console.WriteLine();
    }
    public void CreateNewGoal()
    {
        string userInput;

        Console.WriteLine("The types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1":
                {
                    _goals.Add(new SimpleGoal());
                    break;
                }
            case "2":
                {
                    _goals.Add(new EternalGoal());
                    break;
                }
            case "3":
                {
                    _goals.Add(new ChecklistGoal());
                    break;
                }
        }    
    }
    public void DisplayGoal()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are currently 0 goals in the stored list. Please create or load from a file.");
            return;
        }
        int goalCount = 1;
        Console.WriteLine("The goals are:");
        foreach (Goal g in _goals)
        {
            if (g is ChecklistGoal checklist)
                Console.WriteLine($"{goalCount}. [{g.isComplete()}] {g.GetName()} ({g.GetDescription()}) -- Currently completed: {checklist.GetAmountCompleted()} / {checklist.GetAmountToComplete()} ");
            else
                Console.WriteLine($"{goalCount}. [{g.isComplete()}] {g.GetName()} ({g.GetDescription()})");
            
            goalCount += 1;
        }
    }
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are currently 0 goals in the stored list. Please create or load from a file.");
            return;
        }
        int goalCount = 1;
        int userInput = 99;
        Console.WriteLine("The goals are:");
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{goalCount}. {g.GetName()}");
            goalCount += 1;
        }
        while (_goals.Count < userInput)
        {
            Console.Write("Which goal did you accomplish? ");
            userInput = int.Parse(Console.ReadLine());
        }
        //reduced to match index number in the list
        userInput -= 1;

        if (_goals[userInput] is SimpleGoal simpleGoal)
            {
                if (!simpleGoal.CheckComplete())
                {
                    _goals[userInput].CompleteGoal();
                    _accumulatedPoints += _goals[userInput].GetPoints();
                    Console.WriteLine($"Congratulations! You have earned {_goals[userInput].GetPoints()} points!");
                    Console.WriteLine($"You now have {_accumulatedPoints} points.");
                }
                else
                Console.WriteLine("You've already completed this goal.");
                
            }
        else if (_goals[userInput] is ChecklistGoal checklistGoal)
        {
            if (!checklistGoal.GetIsDone())
            {
                _goals[userInput].CompleteGoal();
                if (checklistGoal.GetAmountCompleted() == checklistGoal.GetAmountToComplete())
                {
                    _accumulatedPoints += checklistGoal.GetBonusPoints();
                    Console.WriteLine($"Congratulations! You have earned {checklistGoal.GetBonusPoints()} bonus points!");
                }
                else
                {
                    _accumulatedPoints += _goals[userInput].GetPoints();
                    Console.WriteLine($"Congratulations! You have earned {_goals[userInput].GetPoints()} points!");
                }
                Console.WriteLine($"You now have {_accumulatedPoints} points.");
            }
            else
                Console.WriteLine("You've already completed this goal.");
        }
        //eternal goal
        else
        {
            _goals[userInput].CompleteGoal();
            _accumulatedPoints += _goals[userInput].GetPoints();
            Console.WriteLine($"Congratulations! You have earned {_goals[userInput].GetPoints()} points!");
            Console.WriteLine($"You now have {_accumulatedPoints} points.");
        }
    }

    public void SaveGoals()
    {
        string fileName;
        Console.Write("What is the filename for this goal file? ");
        fileName = Console.ReadLine();

        Console.WriteLine($"Saving your journal to: {fileName}...");
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine($"#{_accumulatedPoints}");
            foreach (Goal g in _goals)
            {
                if (g is SimpleGoal simple)
                    outputFile.WriteLine($"{simple.GetType()}~{simple.GetName()}~{simple.GetDescription()}~{simple.GetPoints()}~{simple.GetIsComplete()}");
                else if (g is EternalGoal eternal)
                    outputFile.WriteLine($"{eternal.GetType()}~{eternal.GetName()}~{eternal.GetDescription()}~{eternal.GetPoints()}");
                else if (g is ChecklistGoal checkList)
                    outputFile.WriteLine($"{checkList.GetType()}~{checkList.GetName()}~{checkList.GetDescription()}~{checkList.GetPoints()}~{checkList.GetBonusPoints()}~{checkList.GetAmountToComplete()}~{checkList.GetAmountCompleted()}");
            }
        }
        Console.WriteLine("Saving complete!");
    }
    public void LoadGoals()
    {
        string fileName;
        Console.Write("What is the filename for the goal file? ");
        fileName = Console.ReadLine();
        string[] loadLines = System.IO.File.ReadAllLines(fileName);

        //clears the entry list before loading from the saved file
        _goals.Clear();
        Console.WriteLine("Loading from file...");
        foreach (string line in loadLines)
        {
            if (line.StartsWith("#"))
            {
                string[] brokenNum = line.Split("#");
                _accumulatedPoints = int.Parse(brokenNum[1]);
                continue;
            }

            string[] brokenLines = line.Split("~");
            string brokenType = brokenLines[0];            
            string brokenName = brokenLines[1];
            string brokenDescription = brokenLines[2];
            int brokenPoints = int.Parse(brokenLines[3]);

            if (brokenType == "SimpleGoal")
            {
                bool brokenBool = bool.Parse(brokenLines[4]);
                _goals.Add(new SimpleGoal(brokenName, brokenDescription, brokenPoints, brokenBool));
            }
            else if (brokenType == "EternalGoal")
            {
                _goals.Add(new EternalGoal(brokenName, brokenDescription, brokenPoints));
            }
            else if (brokenType == "ChecklistGoal")
            {
                int brokenBonusPoints = int.Parse(brokenLines[4]);
                int brokenAmountToComplete = int.Parse(brokenLines[5]);
                int brokenCompleted = int.Parse(brokenLines[6]);
                _goals.Add(new ChecklistGoal(brokenName, brokenDescription, brokenPoints, brokenBonusPoints, brokenAmountToComplete, brokenCompleted));
            }
        }
        Console.WriteLine("Loading complete, the current Goal list has been overwritten with the saved file.");
    }
    public void DeleteGoal()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are currently 0 goals in the stored list. Please create or load from a file.");
            return;
        }
        int goalCount = 1;
        int userInput = 99;
        Console.WriteLine("The goals are:");
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{goalCount}. {g.GetName()}");
            goalCount += 1;
        }
        while (_goals.Count < userInput)
        {
            Console.Write("Which goal would you like to remove? ");
            userInput = int.Parse(Console.ReadLine());
        }
        //reduced to match index number in the list
        userInput -= 1;
        Console.WriteLine($"The goal: '{_goals[userInput].GetName()}' has been removed from the list.");
        _goals.RemoveAt(userInput);
    }
    public void SpendPoints()
    {
        int itemPrice = 0;
        Console.WriteLine();
        Console.WriteLine("Welcome to the item shop! you can spend points to purchase the following items:");
        Console.WriteLine("1. A monkey plushie - 50 points");
        Console.WriteLine("2. A deck of cards - 100 points");
        Console.WriteLine("3. A $20 Costco giftcard - 250 points");
        Console.WriteLine("4. A brand new bike - 750 points");
        Console.WriteLine("5. A Gaming PC - 1000 points");
        Console.WriteLine("6. A brand new car - 2000 points");
        Console.Write("Select an item from the menu: ");
        string userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1":
                {
                    itemPrice = 50;
                    break;
                }
            case "2":
                    {
                    itemPrice = 100;
                    break;
                }
            case "3":
                {
                    itemPrice = 250;
                    break;
                }
            case "4":
                {        
                    itemPrice = 750;                
                    break;
                }
            case "5":
                {
                    itemPrice = 1000;
                    break;
                }
            case "6":
                {
                    itemPrice = 2000;
                    break;
                }
            default:
                Console.WriteLine("Invalid option.");
                return;
        }    
        if (itemPrice <= _accumulatedPoints)
        {
            _accumulatedPoints -= itemPrice;
            Console.WriteLine("Item purchased!");
        }
        else
        Console.WriteLine("Insufficient balance, come back when you have enough points!");
    }
}