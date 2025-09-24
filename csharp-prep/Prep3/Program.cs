using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int guessCount = 0;
        bool loop = true;
        //Console.Write("What is the magic number? ");
        //int magicNumber = int.Parse(Console.ReadLine());
        while (loop == true)
        {
            guessCount += 1;
            Console.Write("What is your guess? ");
            int guess = int.Parse(Console.ReadLine());
            if (guess == magicNumber)
            {
                Console.WriteLine("You guessed it right!");
                loop = false;
            }
            else
            {
                if (guess >= magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess <= magicNumber)
                {
                    Console.WriteLine("Higher");
                }
            }
        }
        Console.WriteLine($"It took you {guessCount} tries to get the asnwer.");
    }
}