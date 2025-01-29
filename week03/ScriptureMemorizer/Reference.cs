using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int Verse { get; }
    public int? EndVerse { get; }

    public Reference(string book, int chapter, int verse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        Verse = verse;
        EndVerse = endVerse;
    }

    public string GetDisplayText()
    {
        return EndVerse == null ? $"{Book} {Chapter}:{Verse}" : $"{Book} {Chapter}:{Verse}-{EndVerse}";
    }
}