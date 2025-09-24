using System;

class Program
{

    static void Main(string[] args)
    {
        string givenname;
        int favNum;
        int BirthYear;
        DisplayWelcome();
        PromptUserName(out givenname);
        int finalNum = PromptUserNumber(out favNum);
        PromptUSerBirthYear(out BirthYear);
        int squared = SquareNumber(finalNum);
        DisplayResult(givenname, BirthYear, squared);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static void PromptUserName(out string givenname)
    {
        Console.Write("What is your name? ");
        givenname = Console.ReadLine();
    }
    static int PromptUserNumber(out int favNum)
    {
        Console.Write("What is your favorite number? ");
        favNum = int.Parse(Console.ReadLine());
        return favNum;
    }
    static void PromptUSerBirthYear(out int BirthYear)
    {
        Console.Write("When is your Birth Year? ");
        BirthYear = int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int finalNum)
    {
        int squared = finalNum * finalNum;
        return squared;
    }
    static void DisplayResult(string givenname, int BirthYear, int squared)
    {
        int age = 2025 - BirthYear;
        Console.WriteLine($"Brother {givenname}, the square of your number is {squared}");
        Console.WriteLine($"Brother {givenname}, you will turn {age} this year.");
    }
}