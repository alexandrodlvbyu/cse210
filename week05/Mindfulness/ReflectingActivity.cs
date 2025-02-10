class ReflectingActivity : Activity
{
    private List<string> _prompts = new() { "Think of a time you stood up for someone.", "Think of a time you overcame a challenge." };
    private List<string> _questions = new() { "Why was this meaningful?", "How did you feel afterward?" };
    
    public ReflectingActivity()
    {
        Name = "Reflecting Activity";
        Description = "This activity helps you reflect on times of strength and resilience.";
    }
    
    protected override void Run()
    {
        DisplayPrompt();
        DisplayQuestions();
    }
    
    private void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
        ShowCountdown(5);
    }
    
    private void DisplayQuestions()
    {
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(5);
        }
    }
    
    private string GetRandomPrompt() => _prompts[new Random().Next(_prompts.Count)];
    private string GetRandomQuestion() => _questions[new Random().Next(_questions.Count)];
}