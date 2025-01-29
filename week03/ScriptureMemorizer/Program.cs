class Program
{
    static void Main()
    {
        List<(Reference, string)> scriptures = LoadScripturesFromFile("scriptures.txt");
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in the file.");
            return;
        }

        Random random = new Random();
        var selectedScripture = scriptures[random.Next(scriptures.Count)];
        Scripture scripture = new Scripture(selectedScripture.Item1, selectedScripture.Item2);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program ending...");
                break;
            }
        }
    }

    static List<(Reference, string)> LoadScripturesFromFile(string filePath)
    {
        List<(Reference, string)> scriptures = new List<(Reference, string)>();
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: File not found.");
            return scriptures;
        }

        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split(new[] { ' ' }, 2);
            if (parts.Length == 2)
            {
                Reference reference = ParseReference(parts[0]);
                scriptures.Add((reference, parts[1]));
            }
        }
        return scriptures;
    }

    static Reference ParseReference(string referenceText)
    {
        int spaceIndex = referenceText.LastIndexOf(' ');
        string book = referenceText.Substring(1, spaceIndex);
        string chapterVerse = referenceText.Substring(spaceIndex + 1);

        string[] parts = chapterVerse.Split(':');
        int chapter = int.Parse(parts[0]);
        string[] verseParts = parts[1].Split('-');

        if (verseParts.Length == 1)
        {
            return new Reference(book, chapter, int.Parse(verseParts[0]));
        }
        else
        {
            return new Reference(book, chapter, int.Parse(verseParts[0]), int.Parse(verseParts[1]));
        }
    }
}