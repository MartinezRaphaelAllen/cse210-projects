using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int userInput = 1;
        int sum = 0;
        double average = 0;
        int largestNumber;
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter a Number: ");
            userInput = int.Parse(Console.ReadLine());
            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }
        while (userInput != 0);

        foreach (int number in numbers)
        {
            sum += number;
        }
        average = (double)sum / numbers.Count;
        largestNumber = numbers.Max();
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");
    }
}