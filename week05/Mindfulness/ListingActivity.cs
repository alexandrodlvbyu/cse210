class ListingActivity : Activity
{
    private List<string> _prompts = new() { "Who do  you appreciate?", "What are your strengths?", "Who have you helped this week?" };
    private int _count;
    
    public ListingActivity()
    {
        Name = "Listing Activity";
        Description = "This activity helps you list things that bring positivity to your life.";
    }
    
    protected override void Run()
    {
        Console.WriteLine(GetRandomPrompt());
        ShowCountdown(5);
        GetListFromUser();
        Console.WriteLine($"You listed {_count} items!");
    }
    
    private string GetRandomPrompt() => _prompts[new Random().Next(_prompts.Count)];
    
    private void GetListFromUser()
    {
        _count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.Write($"Item {_count + 1}: ");
            Console.ReadLine();
            _count++;
        }
    }
}