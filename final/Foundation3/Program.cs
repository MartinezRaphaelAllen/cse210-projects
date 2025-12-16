using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Random _randomGenerator = new Random();
        List<int> _chosenEvents = new List<int>(){};
        List<string> _addresses = new List<string>()
        {
          "Blk 30 Lt 21,Subic,Olongapo,Philippines",
          "139 W 4th S,Mesa,Arizona,USA",
          "1812-994 Minamisawa,Sapporo,Hokkaido,Japan",
          "52 E 7th N,Provo,Utah,USA"  
        };
        List<string> _events = new List<string>()
        {
            "Reception,Soren and Samantha's Wedding,Come join us as we celebrate the union of this new couple,12-18-2025,7 PM,soren.pack@gmail.com,false",
            "Lecture,How to overcome procrastination,Free professional workshop from the Institute of Productivity,11-16-2022,3 PM,Dr. Will Andersen,80",
            "Outdoor,Outdoor Club Annual BBQ,Eat and mingle with the club members at our yearly BBQ Party!,10-03-2027,7 AM,Sunny"
        };

        List<Event> _formulatedEvents = new List<Event>(){};

        for (int i = 1; i <= 2; i++)
        {
            int chosenEvent;
            do
               chosenEvent = _randomGenerator.Next(0,3);
            while (_chosenEvents.Contains(chosenEvent));
            _chosenEvents.Add(chosenEvent);

            string[] brokenLines = _events[chosenEvent].Split(",");

            string eventType = brokenLines[0];
            string title = brokenLines[1];
            string description = brokenLines[2];
            string date = brokenLines[3];
            string time = brokenLines[4];

            switch (eventType)
            {
                case "Reception":
                    {
                        string email = brokenLines[5];
                        bool RSVP = bool.Parse(brokenLines[6]);

                        _formulatedEvents.Add(new Reception(title, description, date, time, email, RSVP));
                        break;
                    }
                case "Lecture":
                    {
                        string speaker = brokenLines[5];
                        int capacity = int.Parse(brokenLines[6]);

                        _formulatedEvents.Add(new Lecture(title, description, date, time, speaker, capacity));
                        break;
                    }
                case "Outdoor":
                    {
                        string weather = brokenLines[5];

                        _formulatedEvents.Add(new Outdoor(title, description, date, time, weather));
                        break;
                    }    
            }
        }

        //set the addresses for the chosen events
        foreach (Event e in _formulatedEvents)
        {
            int chosenAddress = _randomGenerator.Next(0,4);
            string [] brokenLines = _addresses[chosenAddress].Split(",");

            string streetAddress = brokenLines[0];
            string city = brokenLines[1];
            string state = brokenLines[2];
            string country = brokenLines[3];
            e.SetAddress(streetAddress, city, state, country);
        }

        int counter = 1;
        foreach (Event e in _formulatedEvents)
        {
            Console.WriteLine($"--{counter}--");
            Console.WriteLine("STANDARD DETAILS");
            Console.WriteLine(e.StandardDetails());
            Console.WriteLine();
            Console.WriteLine("FULL DETAILS");
            Console.WriteLine(e.FullDetails());
            Console.WriteLine();
            Console.WriteLine("SHORT DESCRIPTION");
            Console.WriteLine(e.ShortDescription());
            Console.WriteLine();

            counter++;
        }
    }
}