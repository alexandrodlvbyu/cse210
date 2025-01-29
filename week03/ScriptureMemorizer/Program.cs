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
        static Reference ParseReference(string referenceText)
{
    int colonIndex = referenceText.IndexOf(':');

    // Check if ':' exists in the referenceText
    if (colonIndex == -1)
    {
        throw new FormatException($"Invalid scripture reference format: {referenceText}");
    }

    string bookAndChapter = referenceText.Substring(0, colonIndex); // Extract "John 3"
    string versePart = referenceText.Substring(colonIndex + 1);     // Extract "16"

    int spaceIndex = bookAndChapter.LastIndexOf(' ');
    if (spaceIndex == -1)
    {
        throw new FormatException($"Invalid book and chapter format: {bookAndChapter}");
    }

    string book = bookAndChapter.Substring(0, spaceIndex); // Extract "John"
    int chapter = int.Parse(bookAndChapter.Substring(spaceIndex + 1)); // Extract "3"

    if (versePart.Contains('-'))
    {
        string[] verseRange = versePart.Split('-');
        int startVerse = int.Parse(verseRange[0]);
        int endVerse = int.Parse(verseRange[1]);

        return new Reference(book, chapter, startVerse, endVerse);
    }
    else
    {
        int verse = int.Parse(versePart);
        return new Reference(book, chapter, verse);
    }
}
