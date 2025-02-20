public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2023, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2023, 11, 4), 45, 25),
            new Swimming(new DateTime(2023, 11, 5), 60, 50)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}