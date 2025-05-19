using System;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Mood { get; set; } 

    public Entry(string prompt, string response, string mood = "Neutral")
    {
        Prompt = prompt;
        Response = response;
        Mood = mood;
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public override string ToString()
    {
        return $"{Date} | {Prompt} | {Response} | Mood: {Mood}";
    }
}
