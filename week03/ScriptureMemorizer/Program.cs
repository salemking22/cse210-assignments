#This program exceeds requirements by allowing users to set a custom difficulty level, dynamically adjusting the memorization challenge. It also supports scripture loading from external files, enabling flexibility beyond manual input. Additionally, it ensures words are hidden progressively without selecting already-hidden words, enhancing the memorization process.
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Would you like to (1) Load scripture from a file or (2) Enter one manually?");
        
        Scripture scripture;
        if (Console.ReadLine() == "1")
        {
            scripture = LoadScriptureFromFile();
        }
        else
        {
            scripture = GetManualScripture();
        }

        Console.WriteLine("\nChoose difficulty level (number of words hidden per step): ");
        int difficulty = int.Parse(Console.ReadLine());

        Console.Clear();

        while (!scripture.IsFullyHidden())
        {
            Console.WriteLine(scripture);
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            
            if (Console.ReadLine()?.ToLower() == "quit") break;

            Console.Clear();
            scripture.HideRandomWords(difficulty);
        }

        Console.WriteLine("Well done! You've memorized the scripture.");
    }

    static Scripture LoadScriptureFromFile()
    {
        Console.WriteLine("Enter the filename:");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. Using default scripture.");
            return new Scripture(new Reference("John", 3, 16), "For God so loved the world...");
        }

        string[] lines = File.ReadAllLines(filename);
        var refParts = lines[0].Split(" ");
        var reference = new Reference(refParts[0], int.Parse(refParts[1]), int.Parse(refParts[2]));
        return new Scripture(reference, lines[1]);
    }

    static Scripture GetManualScripture()
    {
        Console.WriteLine("Enter scripture reference (e.g., John 3 16): ");
        string[] parts = Console.ReadLine().Split(" ");
        var reference = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]));

        Console.WriteLine("Enter scripture text:");
        string text = Console.ReadLine();

        return new Scripture(reference, text);
    }
}
    
