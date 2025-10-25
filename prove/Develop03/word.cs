public class Word
{
    private string[] _parsedList;
    private int _hiddenIndex;

    public Word(string[] parsedList, int hiddenIndex)
    {
        SetParsedList(parsedList);
        SetHiddenIndex(hiddenIndex);
    }

    public void SetParsedList(string[] parsedList)
    {
        _parsedList = parsedList;
    }

    public void SetHiddenIndex(int hiddenindex)
    {
        _hiddenIndex = hiddenindex;
    }
    
    public string ConvertToHidden()
    {
        string constructedWord = "";
        string inputString = _parsedList[_hiddenIndex];
        char[] brokenWord = inputString.ToCharArray();

        for (int i = 0; i < brokenWord.Length; i++)
        {
            constructedWord += "_";
        }

        return constructedWord;
    }
    
}