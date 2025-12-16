using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Random _randomGenerator = new Random();
        List<Activity> _activities = new List<Activity>(){};
        List<int> _chosenEvents = new List<int>(){};
        List<string> _runningEvents = new List<string>()
        {
            "03 Nov 2022,30,4.8",
            "30 Dec 2018,45,5",
            "15 Jan 2004,80,8.2"
        };
        List<string> _swimmingEvents = new List<string>()
        {
            "04 July 2013,60,8",
            "07 Apr 1998,70,10",
            "27 Feb 2010,30,5"  
        };

        List<string> _cyclingEvents = new List<string>()
        {
            "06 May 2003,90,3.2",
            "28 Oct 1970,120,3.5",
            "01 Aug 2012,60,2.4"
        };

        //setting the events
        for (int i = 1; i <= 3; i++)
        {
            int chosenEvent;
            do
            {
                chosenEvent = _randomGenerator.Next(0,3);
            }while (_chosenEvents.Contains(chosenEvent));
            _chosenEvents.Add(chosenEvent);

            switch (chosenEvent)
            {
                case 0:
                    {
                        int chosenValue = _randomGenerator.Next(0,3);
                        string[] brokenLines = _runningEvents[chosenValue].Split(",");

                        string date = brokenLines[0];
                        int length = int.Parse(brokenLines[1]);
                        double distance = double.Parse(brokenLines[2]);

                        _activities.Add(new Running(date, length, distance));
                        break;
                    }
                case 1:
                    {
                        int chosenValue = _randomGenerator.Next(0,3);
                        string[] brokenLines = _swimmingEvents[chosenValue].Split(",");

                        string date = brokenLines[0];
                        int length = int.Parse(brokenLines[1]);
                        int laps = int.Parse(brokenLines[2]);

                        _activities.Add(new Swimming(date, length, laps));
                        break;   
                    }
                case 2:
                    {
                        int chosenValue = _randomGenerator.Next(0,3);
                        string[] brokenLines = _cyclingEvents[chosenValue].Split(",");

                        string date = brokenLines[0];
                        int length = int.Parse(brokenLines[1]);
                        double speed = double.Parse(brokenLines[2]);

                        _activities.Add(new Cycling(date, length, speed));
                        break;
                    }
            }
        }

        foreach (Activity a in _activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}