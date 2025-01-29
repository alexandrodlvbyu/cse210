using System;
using System.Collections.Generic;

// Classe Comment pour stocker les commentaires d'une vidéo
class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }
    
    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}