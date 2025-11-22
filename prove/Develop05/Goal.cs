public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal()
    {
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetPoints()
    {
        return _points;
    }
    public string GetDescription()
    {
        return _description;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }
    public void SetPoints(int points)
    {
        _points = points;
    }

    public abstract void CreateGoal();
    public abstract string isComplete();
    public abstract void CompleteGoal();
}