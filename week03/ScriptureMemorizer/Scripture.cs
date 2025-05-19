using System;
using System.Collections.Generic;

class Scripture
{
    public Reference Ref { get; private set; }
    private List<Word> Words;

    public Scripture(Reference reference, string text)
    {
        Ref = reference;
        Words = new List<Word>();

        foreach (string word in text.Split(" ")) 
        {
            Words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count)
    {
        var visibleWords = Words.FindAll(word => !word.IsHidden);
        if (visibleWords.Count == 0) return; 

        var random = new Random();
        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public override string ToString()
    {
        return $"{Ref}\n" + string.Join(" ", Words);
    }

    public bool IsFullyHidden() => Words.TrueForAll(word => word.IsHidden);
}
