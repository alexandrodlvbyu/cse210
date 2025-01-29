using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries; 

    public Journal()
    {
        _entries = new List<Entry>(); 
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");  
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            _entries.Clear(); 
            string[] lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2]);
                    _entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
