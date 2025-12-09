using System;

class Program
{
    static void Main(string[] args)
    {
        Random _randomGenerator = new Random();
        List<Video> _videos = new List<Video>(){};
        List<string> _comments = new List<string>()
        {
            "Life changing! Thank you for posting this, you earned a subscriber.",
            "Finally, a video that's in 1080p. Kidding aside, I learned a lot from this video!",
            "My dad would love this video, Good job!",
            "Brings a tear to my eye, a masterpiece of a video. I subbed to your channel!"
        };
        List<string> _names = new List<string>()
        {
            "Tylergreen",
            "CrewMate5612",
            "MooMaster1998",
            "Turdlelover",
            "Stickman1201",
            "Ninjapyro"
        };

        _videos.Add(new Video("How to cook Curry", "International Cuisines", 15));
        _videos.Add(new Video("Osaka: Japan's kitchen", "NHK", 20));
        _videos.Add(new Video("The rise and fall of Natus Vincere", "Blast Premier", 45));
        _videos.Add(new Video("The history of the Philippines condensed", "TheHistoryNerd", 30));

        //set the randomized comments first
        foreach (Video v in _videos)
        {
            List<int> chosenNames = new List<int>(){};
            List<int> chosenComment = new List<int>(){};
            int nameIndex;
            int commentIndex;
            int numberOfComments = _randomGenerator.Next(3, 5);
            for (int i = 0; i < numberOfComments; i++)
            {
                do
                {
                    nameIndex = _randomGenerator.Next(0, 6);
                } while (chosenNames.Contains(nameIndex));
                chosenNames.Add(nameIndex);
                do
                {
                    commentIndex = _randomGenerator.Next(0,4);
                } while (chosenComment.Contains(commentIndex));
                chosenComment.Add(commentIndex);
                v.AddComment(_names[nameIndex], _comments[commentIndex]);
            }
        }

        //display
        foreach (Video v in _videos)
        {
            List<Comment> comments = v.GetComments();
            Console.WriteLine($"Title: {v.GetTitle()}");
            Console.WriteLine($"Author: {v.GetAuthor()}");
            Console.WriteLine($"Length: {v.GetLength()} minutes");
            Console.WriteLine($"Number of Comments: {v.ReturnNumberOfComments()}");

            foreach (Comment c in comments)
            {
                Console.WriteLine($"    {c.GetName()}");
                Console.WriteLine($"    {c.GetText()}");
            }

            //whitespace
            Console.WriteLine();
        }
    }
}