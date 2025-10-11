using System.IO;

public class Journal
{
    string _fileName = "journal.csv";
    List<Entry> _entries = new List<Entry>();

    public Journal()
    {
    }
    public string DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
        return Console.ReadLine();
    }
    public void Write()
    {
        Entry newEntry = new Entry();
        (newEntry._entryText, newEntry._prompt, newEntry._date) = newEntry.JournalEntry();
        _entries.Add(newEntry);
    }
    public void Display()
    {
        if (_entries.Count() == 0)
        {
            Console.WriteLine("There aren't any entries to display currently, please write or load from a file.");
            Console.WriteLine();
        }
        else
        {
            foreach (Entry e in _entries)
            {
                Console.WriteLine($"Date: {e._date} - Prompt: {e._prompt}");
                Console.WriteLine(e._entryText);
                Console.WriteLine();
            }
        }
    }
    public void Load()
    {
        string[] loadLines = System.IO.File.ReadAllLines(_fileName);

        //clears the entry list before loading from the saved file
        _entries.Clear();
        Console.WriteLine("Loading from file...");
        foreach (string line in loadLines)
        {
            string[] brokenLines = line.Split("~");
            string brokenDate = brokenLines[0];
            string brokenPrompt = brokenLines[1];
            string brokenResponse = brokenLines[2];

            Entry newEntry = new Entry();
            newEntry._date = brokenDate;
            newEntry._prompt = brokenPrompt;
            newEntry._entryText = brokenResponse;
            _entries.Add(newEntry);
        }
        Console.WriteLine("Loading complete, the current entries have been overwritten.");
        Console.WriteLine();
    }

    public void Save()
    {
        Console.WriteLine($"Saving your journal to: {_fileName}...");
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            foreach (Entry e in _entries)
            {
                outputFile.WriteLine($"{e._date}~{e._prompt}~{e._entryText}");
            }
        }
        Console.WriteLine("Saving complete!");
        Console.WriteLine();
    }
}