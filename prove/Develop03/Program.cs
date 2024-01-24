using System;

class Programs
    {

public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Reference(string book, int chapter, int startVerse, int endVerse = -1)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse == -1 ? startVerse : endVerse;
    }

    public override string ToString()
    {
        return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

public class Word
{
    public string Text { get; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }
}

public class Scripture
{
    private readonly List<Word> words;

    public Reference Reference { get; }
    public bool AllWordsHidden => words.All(word => word.IsHidden);

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"Scripture: {Reference}");
        foreach (var word in words)
        {
            Console.Write(word.IsHidden ? " _" : $" {word.Text}");
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, 4); // You can adjust the range based on your preference

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = random.Next(words.Count);
            words[randomIndex].IsHidden = true;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world...");

        do
        {
            scripture.Display();
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords();
        } while (!scripture.AllWordsHidden);
    }
}

    }
