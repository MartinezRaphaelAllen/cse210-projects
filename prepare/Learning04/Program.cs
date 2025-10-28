using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment a = new MathAssignment("Samuel Bennett", "Multiplication", "7.3", "8-19");
        Console.WriteLine(a.GetSummary());
        Console.WriteLine(a.GetHomeworkList());

        WritingAssignment b = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(b.GetSummary());
        Console.WriteLine(b.GetWritingInformation());
    }
}