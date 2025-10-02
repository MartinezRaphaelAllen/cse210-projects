using System;

class Resume
{
    public string name;
    public List<Job> _jobs = new List<Job>();

    public Resume()
    {

    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.DisplayJobDetails();
        }
    }
}