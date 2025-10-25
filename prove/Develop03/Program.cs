using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        bool _programEnd = true;
        Scripture newScripture = new Scripture(
            "And now behold, I say unto you, my brethren, if ye have experienced a change of heart, and if ye have felt to sing the song of redeeming love, I would ask, can ye feel so now? Have ye walked, keeping yourselves blameless before God? Could ye say, if ye were called to die at this time, within yourselves, that ye have been sufficiently humble? That your garments have been cleansed and made white through the blood of Christ, who will come to redeem his people from their sins?",
            "Alma",
            5,
            26,
            27
        );

        newScripture.DisplayText();
        Console.WriteLine();
        while (_programEnd)
        {
            Console.WriteLine("Press enter or type 'quit' to finish: ");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            {
                _programEnd = newScripture.Quit();
            }
            else
            {
                Console.Clear();
                bool canKeepHiding = newScripture.HideWords();
                newScripture.DisplayText();
                Console.WriteLine();

                if (!canKeepHiding)
                {
                    Console.Clear();
                    _programEnd = newScripture.Quit();
                }
            }
        }
    }
}