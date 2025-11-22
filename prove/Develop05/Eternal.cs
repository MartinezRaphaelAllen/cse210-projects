public class EternalGoal : Goal
{

    public EternalGoal(string name, string description, int points)
    {
        base.SetName(name);
        base.SetDescription(description);
        base.SetPoints(points);
    }
    public EternalGoal()
    {
        CreateGoal();
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
    }

    public override string isComplete()
    {
        return " ";
    }
}