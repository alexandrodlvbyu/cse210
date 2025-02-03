
class Program
{
    static void Main()
    {
       
        List<Video> videos = new List<Video>();
        
        Video video1 = new Video("Introduction to C#", "CodeAcademy", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very informative, thanks!"));
        video1.AddComment(new Comment("Charlie", "Loved the explanations."));
        
        Video video2 = new Video("OOP in C#", "ProgrammingWithMosh", 1200);
        video2.AddComment(new Comment("Dave", "This helped a lot!"));
        video2.AddComment(new Comment("Emma", "Clear and concise."));
        video2.AddComment(new Comment("Frank", "Best video on OOP!"));
        
        Video video3 = new Video("C# Design Patterns", "CodeVault", 900);
        video3.AddComment(new Comment("Grace", "Amazing content!"));
        video3.AddComment(new Comment("Hank", "Well explained."));
        video3.AddComment(new Comment("Ivy", "Thanks for this guide."));
        
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        
    
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
