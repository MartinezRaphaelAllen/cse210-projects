public class ChecklistGoal : Goal
{
    private int _amountToComplete;
    private int _amountCompleted = 0;
    private bool _isDone = false;
    private int _bonusPoints;
    public ChecklistGoal(string name, string description, int points, int bonusPoints, int amtToComplete, int amtCompleted)
    {
        base.SetName(name);
        base.SetDescription(description);
        base.SetPoints(points);
        _bonusPoints = bonusPoints;
        _amountToComplete = amtToComplete;
        _amountCompleted = amtCompleted;
    }
    public ChecklistGoal()
    {
        CreateGoal();
    }
    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public int GetAmountToComplete()
    {
        return _amountToComplete;
    }

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }

    public bool GetIsDone()
    {
        return _isDone;
    }
    public override void CreateGoal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        base.SetName(name);
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        base.SetDescription(description);
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        base.SetPoints(points);
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        _amountToComplete = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accoplishing it that many times? ");
        _bonusPoints = int.Parse(Console.ReadLine());
    }

    public override void CompleteGoal()
    {
        if (_amountCompleted < _amountToComplete)
            _amountCompleted += 1;
    }

    public override string isComplete()
    {
        string mark;
        if (_amountCompleted == _amountToComplete)
        {
            _isDone = true;
            mark = "X";
        }
        else    
            mark = " ";

        return mark;
    }
}