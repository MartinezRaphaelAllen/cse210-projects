public class Reference
{
    private string _book;
    private string _ref;
    public Reference(string bookName, int chapterNumber, int startingVerse, int endingVerse)
    {
        _book = bookName;
        _ref = $"{chapterNumber}:{startingVerse}-{endingVerse}";
    }

    public Reference(string bookName, int chapterNumber, int startingVerse)
    {
        _book = bookName;
        _ref = $"{chapterNumber}:{startingVerse}";
    }

    public string GetReference()
    {
        return $"{_book} {_ref}";
    }
}