using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    // Constructeur pour initialiser une entrée
    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    // Méthode pour afficher une entrée
    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine("------------------------------");
    }

    // Surcharge de ToString() pour simplifier l'affichage
    public override string ToString()
    {
        return $"[{Date}] {Prompt}\n{Response}\n";
    }
}
