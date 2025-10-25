public class Scripture
{
    private Random _randomGenerator = new Random();
    private Word _wordClass;
    private string[] _fullVerse;
    private List<int> _hidden = new List<int>();
    private Reference _scriptureReference;
    public Scripture(string fullVerse, string bookName, int chapterNumber, int startingVerse, int endingVerse)
    {
        _scriptureReference = new Reference(bookName, chapterNumber, startingVerse, endingVerse);
        _fullVerse = fullVerse.Split(" ");
    }

    public Scripture(string fullVerse, string bookName, int chapterNumber, int startingVerse)
    {
        _scriptureReference = new Reference(bookName, chapterNumber, startingVerse);
        _fullVerse = fullVerse.Split(" ");
    }

    public string ConstructVerse()
    {
        string constructedVerse = "";
        for (int i = 0; i < _fullVerse.Length; i++)
        {
            if (!_hidden.Contains(i))
            {
                constructedVerse += $" {_fullVerse[i]}";
            }
            else
            {
                _wordClass = new Word(_fullVerse, i);
                constructedVerse += $" {_wordClass.ConvertToHidden()}";
            } 
        }
        return constructedVerse;
    }
    public void DisplayText()
    {
        Console.WriteLine($"{_scriptureReference.GetReference()} {ConstructVerse()}");
    }

    public bool HideWords()
    {
        if (_hidden.Count >= _fullVerse.Length)
        {
        return false;
        }

        int loopCounter = _randomGenerator.Next(1, 5);
        int chosenNumber;

        for (int i = 0; i < loopCounter; i++)
        {
            //code that stops the loop because all words are already hidden. Fail safe because loop counter is random
            if (_hidden.Count >= _fullVerse.Length)
                break;
            do
            {
                chosenNumber = _randomGenerator.Next(0, _fullVerse.Length);
            }
            while (_hidden.Contains(chosenNumber));

            _hidden.Add(chosenNumber);
        }

        return true;
        
    }
    public string[] GetParsedList()
    {
        return _fullVerse;
    }
    public bool Quit()
    {
        return false;
    }
}