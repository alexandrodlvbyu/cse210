using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Load scriptures from a file
        var scriptures = LoadScripturesFromFile("scriptures.txt");

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in the file.");
            return;
        }

        // Randomly select a scripture
        var random = new Random();
        var selectedScripture = scriptures[random.Next(scriptures.Count)];

        var scripture = new Scripture(selectedScripture.Reference, selectedScripture.Text);
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        while (true)
        {
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            // Hide words and display the updated scripture
            scripture.HideRandomWords(2);
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden! Well done!");
                break;
            }
        }
    }

    // Load scriptures from a file
    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        var scriptures = new List<Scripture>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: File '{filePath}' not found.");
            return scriptures;
        }

        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var parts = line.Split(new[] { ' ' }, 2);
            if (parts.Length == 2)
            {
                var reference = ParseReference(parts[0]);
                var scriptureText = parts[1];
                scriptures.Add(new Scripture(reference, scriptureText));
            }
        }

        return scriptures;
    }

    // Parse reference (handles single and multi-verse references)
    static Reference ParseReference(string referenceText)
    {
        var referenceParts = referenceText.Split(':');
        var bookChapter = referenceParts[0];
        var verseParts = referenceParts[1].Split('-');

        if (verseParts.Length == 1)
        {
            return new Reference(bookChapter, int.Parse(verseParts[0]));
        }

        return new Reference(bookChapter, int.Parse(verseParts[0]), int.Parse(verseParts[1]));
    }
}
