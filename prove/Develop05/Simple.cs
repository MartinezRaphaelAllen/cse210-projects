public class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(string name, string description, int points, bool isComplete)
    {
        base.SetName(name);
        base.SetDescription(description);
        base.SetPoints(points);
        _isComplete = isComplete;
    }
    public SimpleGoal()
    {
        CreateGoal();
    }

    public bool GetIsComplete()
    {
        return _isComplete;
    }
    public bool CheckComplete()
    {
        return _isComplete;
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
        
    }
    public override void CompleteGoal()
    {
        _isComplete = true;
    }

    public override string isComplete()
    {
        string mark;
        if (!_isComplete)
            mark = " ";
        else
            mark = "X";

        return mark;
    }
}