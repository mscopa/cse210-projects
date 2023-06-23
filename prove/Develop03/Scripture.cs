class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private string scriptureText;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        List<string> listWords = text.Split(" ").ToList();
        foreach (string wordString in listWords)
        {
            Word word = new Word(wordString);
            _words.Add(word);            
        }
    }
    public void HideRandomWords(int numberToHide)
    {
        for (int i = 0; i < numberToHide; i++)
        {
            Random random = new Random();
            int index = random.Next(0, _words.Count());
            if (_words[index].IsHidden() == false)
            {
                _words[index].Hide();
            }
            else
            {
                while (_words[index].IsHidden() == true)
                {
                    index = random.Next(0, _words.Count());
                    if (IsCompletelyHidden() == true)
                    {
                        break;
                    }
                }
                _words[index].Hide();
            }
        }
    }
    public string GetDisplayText()
    {
        scriptureText = "";
        foreach (Word word in _words)
        {
            switch (word.IsHidden())
            {
                case true:
                    scriptureText = scriptureText + new string('_', word.GetDisplayText().Length) + " ";
                    break;
                default:
                    scriptureText = scriptureText + word.GetDisplayText() + " ";
                    break;
            }
        }
        return _reference.GetDisplayText() + " " + scriptureText;
    }
    public bool IsCompletelyHidden()
    {
        if (_words.Any(word => word.IsHidden() == false))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}